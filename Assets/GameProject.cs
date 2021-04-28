using System.Collections.Generic;

// Understand what is it
// Know details

public class GameProject
{
    // WHAT
    public List<Player> Players;
    public Vision Vision;

    // How
    public MarketingPlan Marketing;
    public List<GameStage> Gameplay;
}

public class Vision
{
    public List<Emotion> Emotions;
    public List<Decision> Decisions;

    public List<string> Roles;
    public string Atmosphere; // Art, Theme, Words

    public string Challenge; // will be tough, but achievable
    public string Goals;
}

public class MarketingPlan
{
    // HOW TO
    public string GainPlayers;
    public string HoldPlayers;

    // Why people will
    public List<string> Care; // making true fans
    public List<string> Share; // recommending the game
}

public class Loop
{
    public string Name;

    // emotions
    public List<Emotion> Fun;

    // gameplay
    public List<Decision> Decisions;
    public List<string> Errors; // Errors: Consequences, Preventing, Fixing
    public List<string> Education;

    // Low level
    public List<string> Resources;
    public long CycleLength;

    public List<Loop> SubLoops;
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
}
