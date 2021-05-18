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
    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();
    public Vector2 scrollView = Vector2.zero;

    public int Tier = 0;
    public int Macro = 0;

    int counter = 0;

    private void OnGUI()
    {
        Project project = GetProject();

        scrollView = EditorGUILayout.BeginScrollView(scrollView);

        counter = 0;

        Space(25);

        GUILayout.BeginHorizontal();

        Macro = GUILayout.SelectionGrid(Macro, new string[] { "Macro", "Risks", "Gameplay", "Micro", "All" }, 5);

        GUILayout.EndHorizontal();

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

        switch (Tier * 20)
        {
            case 0:
                BigLabel("Community");
                RenderParameter(project.Community.Players.Select(p => p.Name).ToList(), ref counter);
                break;

            case 1:
                BigLabel("Feelings");
                RenderParameter(project.WhatFeelingsDoYouCreate, ref counter);
                break;

            case 2:
                BigLabel("Fun");
                RenderParameter(project.WhatsFun, ref counter);
                break;

            case 3:
                BigLabel("Success");
                RenderParameter(project.WhyThisWillWork, ref counter);
                break;

            case 4:
                BigLabel("PROJECT");
                RenderParameter(project, ref counter);
                break;
        }

        switch (Macro)
        {
            case 0:
                BigLabel("MACRO LEVEL");
                RenderParameter(project.Idea.Description, ref counter);
                RenderParameter(project.Idea.DescriptionParagraph, ref counter);

                RenderParameter(project.Community.Players.Select(p => p.Name).ToList(), ref counter);
                RenderParameter(project.Community.Triggers, ref counter);

                break;

            case 1:
                BigLabel("RISKS");

                RenderParameter(project.WhyThisWillWork, ref counter);
                RenderParameter(project.Risks, ref counter);
                break;

            case 2:
                BigLabel("GAMEPLAY");

                RenderParameter(project.Idea, ref counter);
                RenderParameter(project.Risks, ref counter);
                break;

            case 4:
                BigLabel("ALL");

                RenderParameter(project, ref counter);
                break;

        }

        Space(25);
        InputProperty("", "Unfocus");

        EditorGUILayout.EndScrollView();
    }
}