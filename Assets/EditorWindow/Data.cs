using System.Collections.Generic;
using UnityEditor;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script
// https://stackoverflow.com/questions/2837063/cast-object-to-generic-list

public partial class GDDoc : EditorWindow
{
    public Project GetProject()
    {
        var community = new Community
        {
            Players = new List<Player>
            {
                new Player { Name = "Gamedevs", Description = "" },
                new Player { Name = "Programmers", Description = "" },
            },
            Triggers = new List<string>(), // can take from idea or make random clickbaits
            UniqueTriggers = new List<string>(),

            GainPlayers = "",
            HoldPlayers = "",

            HowToSpeakWithPlayers = ""
        };

        var idea = new Idea
        {
            Atmosphere = "Atmosphere",

            Decisions = new List<Decision>(),
            Playstyles = new List<string>(),
            Challenge = new List<string>(),

            Goals = new List<string>(),
            Roles = new List<string>()
        };

        var success = new Success
        {
            WhyPeopleCantIgnoreIt = "",
            WhyPeopleWillBuyIt = "",
            WhyPeopleWillRecommendIt = "",
            WhyThisWillWork = ""
        };

        var release = new Release
        {
            Iterations = new List<Iteration>(),
            QuantityMetrics = new Dictionary<string, int>(),

            Channels = new List<Channel>(),
        };

        var fun = new List<string> { "Fun" };

        var emotions = new List<Emotion>
        {
            new Emotion { Name = "Feel like a Manager" },
            new Emotion { Name = "Feel like you run your software company" }
        };

        var risks = new List<Risk>
        {
            new Risk { Name = "Don't want to play" },
            new Risk { Name = "Don't want to pay" },
            new Risk { Name = "Don't want to share" }
        };

        Project project = new Project
        {
            WhatsFun = fun,
            WhatFeelingsDoYouCreate = emotions,

            Community = community,
            Idea = idea,
            Release = release,
            WhyThisWillWork = success,

            Risks = risks,
        };

        return project;
    }
}