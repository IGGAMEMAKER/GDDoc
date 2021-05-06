using System.Collections.Generic;

public class Project
{
    public Vision Vision;
    public Release Release;
}

public class Vision
{
    public Idea Idea;
    public List<Player> Players;

    // Success (Urge)
    public List<Emotion> WhatFeelingsDoYouWantToCreate;
    public List<string> WhatsFun;

    public string WhyThisWillWork; // cause people with traits X will get the ability and place to do Y

    public string WhyPeopleCantIgnoreIt; // absurds, CTAs (clickbaits ------ calm stuff)
    public string WhyPeopleWillBuyIt; // followed from the start, were engaged (played betas, gave feedback, spoke with dev)
    public string WhyPeopleWillRecommend;
}

public class Idea
{
    public string Goals;
    public string Challenge; // tough, but achievable
    public string Roles;
    public string Playstyles;

    public List<Decision> Decisions;
    public string Atmosphere; // Art, Theme, Words
}