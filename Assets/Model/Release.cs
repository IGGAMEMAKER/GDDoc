using System.Collections.Generic;

// Project will be released when
// * all / most risks are checked
// * all / most promises are met or surpassed
// * quantitative metrics are fine
// * players are superengaged (there are people who will support game no matter what)
public class Release
{
    public Dictionary<string, int> QuantityMetrics; // subs, wishlists, activity

    public List<Iteration> Iterations;
    // Abstract iteration (campaign prototype, gameplay prototype)
    // MVP; // some fun
    // Demo; // Artsy MVP
    // RELEASE;
    // PostRelease; // DREAM;
}

public class Iteration
{
    public string Name;

    public MarketingActivity Marketing;
    public Gameplay Gameplay;

    // KPIs?
    public int Duration;
    public string Goal; // Risk reducing? Promise execution
}