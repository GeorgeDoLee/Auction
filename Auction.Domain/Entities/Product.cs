﻿namespace Auction.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public int MatchId { get; set; }
    public int LeagueId { get; set; }
    public int SportId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Team? Team { get; set; }
    public Match? Match { get; set; }
    public League? League { get; set; }
    public Sport? Sport { get; set; }
}
