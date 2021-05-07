using System.Collections.Generic;

public class Player
{
    public string Name;
    public string Description;
}

public class Audience
{
    public List<Player> Players;
    public string HowToSpeakWithPlayers;

    // HOW TO
    public string GainPlayers;
    public string HoldPlayers;

    // Understand what is it => Know details
    public List<string> CTAs;

    public List<Channel> Channels;
    // STEAM STORE PAGE

    // MARKETING MATERIALS:
    // * SCREENSHOTS
    // * NAME
    // * TITLE
    // * TRAILERS
    // * DESCRIPTION
}

public class MarketingActivity
{

}

public class Channel
{
    public string Name;
}