using System.Collections.Generic;

// Understand what is it
// Know details

// PreMVP: some fun
// MVP: Art + some fun

// Project will be released when 
// * all / most risks are checked 
// * all / most promises are met or surpassed
// * quantitative metrics are fine
// * players are superengaged

public class Project
{
    // IDEA
    public Vision Vision;

    // IMPLEMENTATION (How)
    public List<Iteration> Iterations;
    public Iteration MVP; // some fun
    public Iteration Demo; // Art + some fun
    public Iteration RELEASE;
    public Iteration PostRelease;
    public Iteration DREAM;

    // RELEASE
    public List<Risk> Risks;
    public Dictionary<string, int> QuantityMetrics; // subs, wishlists, activity
}

public class Vision
{
    // What
    public Idea Idea;

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

public class Marketing
{
    // HOW TO
    public string GainPlayers;
    public string HoldPlayers;

    public List<string> CTAs;

    public List<Channel> Channels;
}

#region Gameplay

public class Loop
{
    public string Name;

    // emotions
    public List<Emotion> Emotions;

    // gameplay
    public List<Decision> Decisions;
    public List<string> Errors; // Errors: Consequences, Preventing, Fixing
    public List<string> Education;

    // Low level
    public List<string> Resources;
    public long CycleLength;

    public List<Loop> SubLoops;
}

public class GameEvent
{
    public string Name;
    public string Purpose;
}

// Fun, Expectations, Emotions, Achievement
public class Emotion
{
    public string Name;
}

public class Decision
{
    public List<string> Choices;
}

public class GameStage
{
    public string Name;
    public List<Loop> Loops;
    public List<GameEvent> Events;
}

#endregion

public class Player
{
    public string Name;
    public string Description;
}

public class Channel
{
    public string Name;
}

// Wanna play
// Wanna pay
// Wanna share

public class Risk
{
    public string Name;
    public string HowToCheckIt;
}

public class Gameplay
{
    public List<GameStage> Stages;
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