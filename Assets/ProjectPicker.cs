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

            Channels = new List<Channel>(),
            CTAs = new List<string>(),
        };


        Idea idea = new Idea
        {
            Atmosphere = "Atmosphere",
            Challenge = new List<string>(),
        };

        Release release = new Release
        {
            Risks = new List<Risk>(),

            Iterations = new List<Iteration>(),
            QuantityMetrics = new Dictionary<string, int>()
        };

        Success success = new Success
        {
            WhyPeopleCantIgnoreIt = "",
            WhyPeopleWillBuyIt = "",
            WhyPeopleWillRecommendIt = "",
            WhyThisWillWork = ""
        };

        Project = new Project
        {
            Audience = audience,
            Idea = idea,
            Release = release,
            WhyThisWillWork = success
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
