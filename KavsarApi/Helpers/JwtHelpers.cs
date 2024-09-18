namespace KavsarApi.Helpers;
internal static class JwtHelpers
{
    internal async static Task<string> GenerateJwtToken(User user, IConfiguration configuration) {
        return await Task.Run(() =>
        {
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            var securityTokenHandler = new JwtSecurityTokenHandler();
            var tokenString = securityTokenHandler.WriteToken(token);
            return tokenString;
        });
    }
}