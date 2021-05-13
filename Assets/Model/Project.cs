using System.Collections.Generic;

public class Project
{
    // Urge
    public List<Emotion> WhatFeelingsDoYouCreate;
    public List<string> WhatsFun;

    public Idea Idea;
    public Audience Audience;

    public Success WhyThisWillWork;
    public List<Risk> Risks;

    public Release Release;
}

public class Idea
{
    public List<string> Goals;
    public List<string> Challenge; // tough, but achievable
    public List<string> Roles;
    public List<string> Playstyles;

    public List<Decision> Decisions;
    public string Atmosphere; // Art, Theme, Words
}

public class Success
{
    public string WhyPeopleCantIgnoreIt; // absurds, CTAs (clickbaits ------ calm stuff)
    public string WhyPeopleWillBuyIt; // followed from the start, were engaged (played betas, gave feedback, spoke with dev)
    public string WhyPeopleWillRecommendIt;
    // Give > Promise
    public string WhyThisWillWork; // cause people with traits X will get the ability and place to do Y
}