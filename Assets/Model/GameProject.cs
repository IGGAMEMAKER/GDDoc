using System.Collections.Generic;

// Understand what is it
// Know details

// Project will be released when
// * all / most risks are checked
// * all / most promises are met or surpassed
// * quantitative metrics are fine
// * players are superengaged (there are people who will support game no matter what)

public class Project
{
    // IDEA
    public Vision Vision;

    // IMPLEMENTATION (How)
    public List<Iteration> Iterations;
    public Iteration MVP; // some fun
    public Iteration Demo; // Artsy MVP
    public Iteration RELEASE;
    public Iteration PostRelease;
    public Iteration DREAM;

    // TWEAKS???

    // RELEASE
    public List<Risk> Risks;
    public Dictionary<string, int> QuantityMetrics; // subs, wishlists, activity
}

public class Vision
{
    // What
    public string WhatFeelingsDoYouWantToCreate;
    public Idea Idea;
    public List<string> WhatsFun;

    // Who
    public List<Player> Players;

    // Success (Urge)
    public string WhyThisWillWork; // cause people with traits X will get the ability and place to do Y

    public string WhyPeopleCantIgnoreIt; // absurds, CTAs (clickbaits ------ calm stuff)
    public string WhyPeopleWillBuyIt; // followed from the start, were engaged (played betas, gave feedback, spoke with dev)
    public string WhyPeopleWillRecommend;
}

public class Idea
{
    public string Goals;
    public string Challenge; // will be tough, but achievable

    public string Roles;
    public string Playstyles;

    public List<Decision> Decisions;
    public List<Emotion> Emotions;

    public string Atmosphere; // Art, Theme, Words
}

public class Player
{
    public string Name;
    public string Description;
}

// Wanna play
// Wanna pay
// Wanna share

public class Risk
{
    public string Name;
    public string HowToCheckIt;
}


// KPIs?
public class Iteration
{
    public string Name;

    public Marketing Marketing;
    public Gameplay Gameplay;

    public int Duration;
    public string Goal;
}
