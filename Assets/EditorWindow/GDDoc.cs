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

        switch (Tier + 200)
        {
            case 0:
                BigLabel("Community");
                RenderParameter(project.Community.Players.Select(p => p.Name).ToList());
                break;

            case 1:
                BigLabel("Feelings");
                RenderParameter(project.WhatFeelingsDoYouCreate);
                break;

            case 2:
                BigLabel("Fun");
                RenderParameter(project.WhatsFun);
                break;

            case 3:
                BigLabel("Success");
                RenderParameter(project.WhyThisWillWork);
                break;

            case 4:
                BigLabel("PROJECT");
                RenderParameter(project);
                break;
        }

        switch (Macro)
        {
            case 0:
                BigLabel("MACRO LEVEL");

                Badge("What are you doing", 1);
                RenderParameter(project.Idea.Description, "1 Sentence Descripion");
                RenderParameter(project.Idea.DescriptionParagraph, "1 Paragraph Descripion");
                Space();

                Badge("Who will play that", 1);
                RenderParameter(project.Community.Players.Select(p => p.Name).ToList());
                RenderParameter(project.Community.Triggers);

                break;

            case 1:
                BigLabel("RISKS");

                RenderParameter(project.WhyThisWillWork);
                RenderParameter(project.Risks);
                break;

            case 2:
                BigLabel("GAMEPLAY");

                RenderParameter(project.Idea);
                break;

            case 4:
                BigLabel("ALL");

                RenderParameter(project);
                break;

        }

        Space(25);
        InputProperty("", "Unfocus");

        EditorGUILayout.EndScrollView();
    }
}