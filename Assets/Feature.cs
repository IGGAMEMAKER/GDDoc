using System.Collections.Generic;

public enum Priority
{
    Low,
    Mid,
    Critical
}

public class Feature
{
    public Priority Priority { get; private set; }
    public int Complexity { get; private set; }
    public List<Goal> Tags;

    public string Name;
    public string Description;

    public Feature()
    {
        Priority = Priority.Low;
        Tags = new List<Goal>();
        Complexity = 0;

        Name = "Unnamed Feature";
        Description = "Needs Feature Description";
    }

    public Feature(Priority priority, List<Goal> tags, int complexity, string name, string description)
    {
        Priority = priority;
        Tags = tags;
        Complexity = complexity;

        Name = name;
        Description = description;
    }

    public bool HasTag(Goal tag)
    {
        return Tags.Contains(tag);
    }

    public void IncreasePriority()
    {
        if (Priority == Priority.Mid)
            Priority = Priority.Critical;

        if (Priority == Priority.Low)
            Priority = Priority.Mid;
    }

    public void DecreasePriority()
    {
        if (Priority == Priority.Mid)
            Priority = Priority.Low;

        if (Priority == Priority.Critical)
            Priority = Priority.Mid;
    }
}
