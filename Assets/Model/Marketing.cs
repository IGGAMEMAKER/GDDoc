using System.Collections.Generic;

public class Player
{
    public string Name;
    public string Description;
}

public class Audience
{
    public List<Player> Players;

    // HOW TO
    public string HowToSpeakWithPlayers;

    public string GainPlayers;
    public string HoldPlayers;

    // Understand what is it => Know details
    public List<string> CTAs;

    // MARKETING MATERIALS:
    // * SCREENSHOTS
    // * NAME
    // * TITLE
    // * TRAILERS
    // * DESCRIPTION
}

public class MarketingActivity { }

public class Channel
{
    public string Name;
}