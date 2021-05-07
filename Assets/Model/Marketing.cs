using System.Collections.Generic;

// Understand what is it => Know details

public class Marketing
{
    // HOW TO
    public string GainPlayers;
    public string HoldPlayers;

    public List<string> CTAs;

    public List<Channel> Channels;
}

public class Channel
{
    public string Name;
}

public class Player
{
    public string Name;
    public string Description;
}

public class Audience
{
    public List<Player> Players;
}
