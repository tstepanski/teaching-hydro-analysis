﻿namespace TeachingHydroAnalysis.Database;

public class Configuration : IConfiguration
{
    public string Host { get; set; } = string.Empty;
    
    public int Port { get; set; }
    
    public string User { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Database { get; set; } = string.Empty;
}