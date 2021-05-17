using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectPicker : MonoBehaviour
{
    public Project Project;

    [MenuItem("GDD/Menu")]
    static void Init()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(GDDoc));
        window.Show();
    }

    // Start is called before the first frame update
    void Start()
    {
        var audience = new Community
        {
            Players = new List<Player>(),

            Triggers = new List<string>(),

            HowToSpeakWithPlayers = ""
        };

        var idea = new Idea
        {
            Atmosphere = "Atmosphere",
            Challenge = new List<string>(),

            Decisions = new List<Decision>(),
            Goals = new List<string>(),
            Playstyles = new List<string>(),
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

        Project = new Project
        {
            WhatsFun = new List<string> { "Fun" },
            WhatFeelingsDoYouCreate = new List<Emotion> { new Emotion() },

            Community = audience,
            Idea = idea,
            Release = release,
            WhyThisWillWork = success,

            Risks = new List<Risk>(),
        };

        // Get the properties of 'Type' class object.
        var myPropertyInfo = typeof(Project).GetFields(); // Type.GetType("Project").GetProperties();

        Debug.Log("Properties of Project are: " + myPropertyInfo.Length);

        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var info = myPropertyInfo[i];
            Debug.Log(info.Name.ToString());
        }
    }
}
