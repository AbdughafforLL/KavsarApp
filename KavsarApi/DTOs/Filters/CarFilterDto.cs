﻿namespace KavsarApi.DTOs.Filters;
public class CarFilterDto
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }
    public string? LicensePlate { get; set; }
}