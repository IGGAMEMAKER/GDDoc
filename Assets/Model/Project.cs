using System.Collections.Generic;

public class Project
{
    // PLAN
    public Idea Idea;
    public Audience Audience;
    public Success WhyThisWillWork;

    // EXECUTION
    public Release Release;
}

public class Idea
{
    // Success (Urge)
    public List<Emotion> WhatFeelingsDoYouWantToCreate;
    public List<string> WhatsFun;

    public string Goals;
    public string Challenge; // tough, but achievable
    public string Roles;
    public string Playstyles;

    public List<Decision> Decisions;
    public string Atmosphere; // Art, Theme, Words
}