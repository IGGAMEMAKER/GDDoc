using System.Collections;

public class Goal
{
    public string Name;
    public string Description;

    public bool Required;
    //public bool MatchesCurrentRelease;

    public Goal()
    {
        Name = "New Goal";
        Description = "Needs description";
    }

    public void ToggleRequired()
    {
        Required = !Required;
    }

    public Goal(string Name, string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }
}
