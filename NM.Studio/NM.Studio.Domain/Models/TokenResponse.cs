﻿namespace NM.Studio.Domain.Models;

public class TokenResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}