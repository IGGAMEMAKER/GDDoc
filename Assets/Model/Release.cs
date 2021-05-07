using System.Collections.Generic;

public class Release
{
    public Dictionary<string, int> QuantityMetrics; // subs, wishlists, activity

    // IMPLEMENTATION (How)
    public List<Iteration> Iterations; // Abstract iteration (campaign prototype, gameplay prototype) // MVP; // some fun // Demo; // Artsy MVP // RELEASE; // PostRelease; // DREAM;
}

public class Iteration
{
    public string Name;

    public Marketing Marketing;
    public Gameplay Gameplay;

    // KPIs?
    public int Duration;
    public string Goal;
}