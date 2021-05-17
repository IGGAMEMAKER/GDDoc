using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script
https://stackoverflow.com/questions/2837063/cast-object-to-generic-list

public partial class GDDoc : EditorWindow
{
    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();
    public Vector2 scrollView = Vector2.zero;

    public int Tier = 0;

    private void OnGUI()
    {
        var community = new Community
        {
            Players = new List<Player> {
                new Player { Name = "Gamedevs", Description = "" },
                new Player { Name = "Programmers", Description = "" },
            },
            Triggers = new List<string>(), // can take from idea or make random clickbaits

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

        var emotions = new List<Emotion> { new Emotion() };

        var risks = new List<Risk>();

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

        scrollView = EditorGUILayout.BeginScrollView(scrollView);

        int counter = 0;

        Space(25);

        if (GUILayout.Button("Community"))
            Tier = 0;

        if (GUILayout.Button("Feelings"))
            Tier = 1;

        if (GUILayout.Button("Fun"))
            Tier = 2;

        if (GUILayout.Button("Why Project Will succeed"))
            Tier = 3;

        if (GUILayout.Button("ALL"))
            Tier = 4;

        Space(25);

        switch (Tier)
        {
            case 0:
                BigLabel("Community");
                RenderParameter(project.Community, ref counter, 1);
                break;

            case 1:
                BigLabel("Feelings");
                RenderParameter(project.WhatFeelingsDoYouCreate, ref counter, 1);
                break;

            case 2:
                BigLabel("Fun");
                RenderParameter(project.WhatsFun, ref counter, 1);
                break;

            case 3:
                BigLabel("Success");
                RenderParameter(project.WhyThisWillWork, ref counter, 1);
                break;

            case 4:
                BigLabel("PROJECT");
                RenderParameter(project, ref counter, 1);
                break;
        }

        //RenderParameter(project, ref counter, 1);

        Space(25);

        EditorGUILayout.EndScrollView();
    }
}