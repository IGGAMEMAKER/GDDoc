﻿using System.Collections.Generic;

public class Player
{
    public string Name;
    public string Description;
}

public class Community
{
    public List<Player> Players;

    public List<string> HowToGainPlayers;
    public List<string> HowToHoldPlayers;

    // Understand what is it => Know details
    public List<string> Triggers;
    public List<string> UniqueTriggers; // What will only be associated with you

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