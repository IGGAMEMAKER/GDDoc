using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPicker : MonoBehaviour
{
    public Project Project;

    // Start is called before the first frame update
    void Start()
    {
        var audience = new Audience
        {
            Players = new List<Player>(),

            CTAs = new List<string>(),

            HowToSpeakWithPlayers = ""
        };

        var idea = new Idea
        {
            Atmosphere = "Atmosphere",
            Challenge = new List<string>(),
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

        Project = new Project
        {
            WhatsFun = new List<string> { "Fun" },
            WhatFeelingsDoYouCreate = new List<Emotion> { new Emotion() },

            Audience = audience,
            Idea = idea,
            Release = release,
            WhyThisWillWork = success,
            Risks = new List<Risk>(),
        };
    }
}
