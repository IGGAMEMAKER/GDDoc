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
                new Player { Name = "People who want to run software company", Description = "People who want to run software company. People, who are (somewhat) into startups, technologies, business" },
                new Player { Name = "GENERAL", Description = "People who want to run software company. People, who are (somewhat) into startups, technologies, business" },
                new Player { Name = "Gamedevs", Description = "" },
                new Player { Name = "Programmers", Description = "" },
            },
            Triggers = new List<string>(), // can take from idea or make random clickbaits

            HowToGainPlayers = new List<string>
            {
                "I am making Serious game about business",
                "I released Serious game about business",
                "[Working on] Upcoming features",
                "I don't know, what to do, help me choose",
                "Hard decisions"
            },
            HowToHoldPlayers = new List<string>
            {
                "Polls",
                "Upcoming features",
                "Playing beta versions",
                "(Mods)"
            },

            MarketingMaterials = new List<MarketingMaterial>
            {
                new MarketingMaterial { Name = "Steam Store Page", Details = "Screenshots, 1 Sentence, Full description" },
                new MarketingMaterial { Name = "Screenshots", Details = "" },
                new MarketingMaterial { Name = "Full description", Details = "" },
                new MarketingMaterial { Name = "Trailer" },
            }
        };

        var idea = new Idea
        {
            Atmosphere = "Atmosphere",
            Description = "Hardcore business simulator. I'm making a game, where you start as solo developer and you need to create a software corporation.",
            DescriptionParagraph = "Start as solo developer and create biggest corporation of all times! Create apps, websites and games, Buy companies & form partnerships, Survive economical crysises, Attract investors and don't let them kick you out",

            Actions = new List<string>(),

            Decisions = new List<string> { },
            Playstyles = new List<string>
            {
                "Aggressive: Eat / bankrupt everyone, infiltrate competitor's direcors board, recruit competitor's best employees (more action, you don't need to adapt)",
                "Collaborative: make partnerships, make conferences, create complex lifechanging projects",
                "Secretive: make schemes, don't pay taxes (worse investment climate, regular need to hide money / fight with governments (via big amount of daughters and offshores), but you save up more $$$)",

                "Be Independent (+you make own decisions, micromanagement) / Rely on investments (+fast growth, more action on macro level)"
            },

            Challenge = new List<string> { "Protect from aggressive acquisitions", "Defend urself against lawsuits" },
            Goals = new List<string> { "Create corporation", "Become TOP1 company" },

            Roles = new List<string> { "Product Owner", "Businessman", "Investor" }
        };

        var success = new Success
        {
            WhyPeopleCantIgnoreIt = "",
            WhyPeopleWillBuyIt = "Cause they followed from the start, were engaged (played betas, gave feedback, spoke with dev)",
            WhyPeopleWillRecommendIt = "Make insane schemes, lawsuit everyone",

            WhyThisWillWork = "Cause people, who dreamed about running software companies, can experience that without need to risk anything"
        };

        var fun = new List<string> { "Acquiring companies", "Parlays", "Bankrupting competitors" };

        var emotions = "Feel like you Manage a software company";

        var risks = new List<Risk>
        {
            new Risk { Name = "Don't want to play" },
            new Risk { Name = "Don't want to pay" },
            new Risk { Name = "Don't want to share" }
        };

        var release = new Release
        {
            Iterations = new List<Iteration>(),
            QuantityMetrics = new Dictionary<string, int>(),

            Channels = new List<Channel>(),
        };

        Project project = new Project
        {
            WhatsFun = fun,
            WhatFeelingDoYouCreate = emotions,

            Community = community,
            Idea = idea,
            Release = release,
            WhyThisWillWork = success,

            Risks = risks,
        };

        return project;
    }
}