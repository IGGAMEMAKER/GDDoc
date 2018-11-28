using System.Collections;

public class Goal
{
    public string Name;
    public string Description;

    public Goal()
    {
        Name = "Unnamed Goal";
        Description = "Needs description";
    }

    public Goal(string Name, string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }
}
