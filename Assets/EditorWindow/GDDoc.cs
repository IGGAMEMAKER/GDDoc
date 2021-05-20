using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script
// https://stackoverflow.com/questions/2837063/cast-object-to-generic-list

public partial class GDDoc : EditorWindow
{
    private const int MarketingTab = 44;

    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();
    public Vector2 scrollView = Vector2.zero;

    public int Tier = 0;

    int counter = 0;

    private void OnGUI()
    {
        Project project = GetProject();

        scrollView = EditorGUILayout.BeginScrollView(scrollView);

        counter = 0;

        Space(25);

        GUILayout.BeginHorizontal();

        var titles = new string[] { "MACRO", "Gameplay", "Community", "Risks", "Iterations", "ALL" };
        var prevTier = Tier;
        Tier = GUILayout.SelectionGrid(Tier, titles, titles.Length);

        GUILayout.EndHorizontal();

        Space(25);

        var title = Tier < titles.Count() ? titles[Tier].ToUpper() : "";

        if (Tier == MarketingTab)
            title = "Marketing";

        BigLabel(title);

        switch (Tier)
        {
            case 0:
                Badge("What are you doing", 1);
                RenderParameterIncludeOnly(project.Idea, "", 1, "Description", "DescriptionParagraph");
                Space();

                Badge("What is cool about your game");
                RenderParameterIncludeOnly(project, "", 1, "WhatsFun", "WhatFeelingDoYouCreate");

                Badge("Who will play your game", 1);
                RenderParameter(project.Community.Players.Select(p => p.Name).ToList(), "", 1);
                //RenderParameterIncludeOnly(project.Community.Players, "", 1, "Name");
                RenderParameterIncludeOnly(project.Community, "", 1, "Triggers");
                Space();

                Badge("Why your game will become successful", 1);
                RenderParameterIncludeOnly(project, "", 1, "WhyThisWillWork");

                Space();

                break;

            //case 1:
            //    //RenderParameterIncludeOnly(project, "", 1, "WhyThisWillWork");
            //    //RenderParameter(project.WhyThisWillWork);

            //    break;

            case 1:
                RenderParameterIncludeOnly(project, "", 1, "Idea");

                break;

            case 2:
                if (GUILayout.Button("Marketing materials"))
                    Tier = MarketingTab;
                RenderParameterIncludeOnly(project.Community, "", 1, "Players", "HowToGainPlayers", "HowToHoldPlayers", "Triggers");

                break;

            case MarketingTab:
                RenderParameterIncludeOnly(project.Community, "", 1, "MarketingMaterials");
                RenderParameterIncludeOnly(project.Release, "", 1, "Channels");

                break;

            case 3:
                RenderParameterIncludeOnly(project, "", 1, "Risks");

                break;

            case 4:
                RenderParameterIncludeOnly(project, "", 1, "Release");

                break;

            default:
                RenderParameter(project);

                break;
        }

        Space(25);

        GUI.SetNextControlName("Unfocus");
        InputProperty("", "Unfocus");

        if (prevTier != Tier)
        {
            EditorGUI.FocusTextInControl("Unfocus");
        }

        EditorGUILayout.EndScrollView();
    }
}