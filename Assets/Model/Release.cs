using System.Collections.Generic;

public class Release
{
    // Project will be released when
    // * all / most risks are checked
    // * all / most promises are met or surpassed
    // * quantitative metrics are fine
    // * players are superengaged (there are people who will support game no matter what)

    public List<Risk> Risks;
    public Dictionary<string, int> QuantityMetrics; // subs, wishlists, activity

    // IMPLEMENTATION (How)
    public List<Iteration> Iterations; // MVP; // some fun // Demo; // Artsy MVP // RELEASE; // PostRelease; // DREAM;

    public string WhyPeopleCantIgnoreIt; // absurds, CTAs (clickbaits ------ calm stuff)
    public string WhyPeopleWillBuyIt; // followed from the start, were engaged (played betas, gave feedback, spoke with dev)
    public string WhyPeopleWillRecommendIt;
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

// Wanna play
// Wanna pay
// Wanna share
public class Risk
{
    public string Name;
    public string HowToCheckIt;
}
