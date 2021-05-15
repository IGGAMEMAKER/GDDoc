using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GDDoc : EditorWindow
{
    string test = "ghgh";

    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();

    private void OnGUI()
    {
        test = GetProp<string>(test, "test");

        EditorGUILayout.LabelField(test);

        var audience = new Audience
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

        Project Project = new Project
        {
            WhatsFun = new List<string> { "Fun" },
            WhatFeelingsDoYouCreate = new List<Emotion> { new Emotion() },

            Audience = audience,
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
            var name = info.Name.ToString();

            if (!Foldouts.ContainsKey(info.Name))
                Foldouts[info.Name] = false;

            Foldouts[info.Name] = EditorGUILayout.Foldout(Foldouts[info.Name], name, true);

            if (Foldouts[info.Name])
                GUILayout.Label(name);
        }
    }

    //public void RenderProp<T>(T prop)
    //{
    //    if ()
    //}

    //public string GetProp<T>(T str)
    //{
    //    T newT = new T();

    //    foreach (var p in typeof(T).GetFields())
    //    {
    //        if (p is string)
    //        {

    //        }
    //    }
    //}

    public string GetProp<T>(string str, string label)
    {
        GUILayout.Label(label);

        return GUILayout.TextField(str, 25);
    }
}