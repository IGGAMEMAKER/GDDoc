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
    // What
    public Vision Vision;
    public List<Player> Players;

    // How
    public MarketingPlan Marketing;
    public List<GameStage> Gameplay;

    // When
    public Dictionary<string, int> QuantityMetrics; // subs, wishlists, activity
    public List<Risk> Risks;

    // Success or fail?
    public string WhyThisWillWork; // Why people will want to play + recommend
}

public class Vision
{
    public string Challenge; // will be tough, but achievable
    public string Goals;

    public string Roles;
    public string Playstyles;

    public List<Decision> Decisions;
    public List<Emotion> Emotions;

    public string Atmosphere; // Art, Theme, Words
}

public class MarketingPlan
{
    // HOW TO
    public string GainPlayers;
    public string HoldPlayers;

    public string CTAs;

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

public class Player
{
    public string Name;
    public string Description;
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

public class Iteration
{
    public string Name;

    public MarketingPlan Marketing;
    public List<GameStage> Gameplay;

    public int Duration;
    public string Goal;
}