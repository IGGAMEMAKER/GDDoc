using System.Collections.Generic;

public class Gameplay
{
    public List<GameStage> Stages;
}

public class GameStage
{
    public string Name;
    public List<Loop> Loops;
    public List<GameEvent> Events;
}

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

public class DecisionDescription
{
    public string Name;
    public string WhyPickingThis;
    public string Consequences;

    public int Importance;
}

public class Decision
{
    public List<DecisionDescription> Choices;
}
