using System.Collections.Generic;

public class Project // project = product + players + time + money
{
    // Urge
    public string WhatFeelingDoYouCreate;
    public List<string> WhatsFun;

    public Idea Idea;
    public Community Community;

    public Success WhyThisWillWork;
    public List<Risk> Risks;

    public Release Release;
}

public class Idea
{
    public string Description; // 1 Sentence
    public string DescriptionParagraph; // 1 Paragraph, Calm description

    public List<string> Roles;

    public List<string> Goals;
    public List<string> Challenge; // tough, but achievable. Challenge = Goals - Obstacles

    public List<string> Playstyles;
    public List<string> Decisions;

    public List<string> Actions;

    public string Atmosphere; // Art, Theme, Words
}

public class Success
{
    public string WhyPeopleCantIgnoreIt; // absurds, CTAs (clickbaits ------ calm stuff)
    public string WhyPeopleWillBuyIt; // followed from the start, were engaged (played betas, gave feedback, spoke with dev)
    public string WhyPeopleWillRecommendIt;
    
    public string WhyThisWillWork; // Give > Promise // cause people with traits X will get the ability and place to do Y
}