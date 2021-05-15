using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GDDoc : EditorWindow
{
    string test = "ghgh";

    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();

    private void OnGUI()
    {
        test = GetProp(test, "test");

        EditorGUILayout.LabelField(test);

        var audience = new Audience
        {
            Players = new List<Player>(),
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

        var myPropertyInfo = typeof(Project).GetFields();

        //Debug.Log("Properties of Project are: " + myPropertyInfo.Length);

        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var info = myPropertyInfo[i];

            RenderFieldInfo(info, "");
        }

        int depth = 0;
        RenderParameter(Project, ref depth);
    }

    public void RenderParameter<T>(T parameter, ref int depth)
    {
        var myPropertyInfo = typeof(T).GetFields();
        Debug.Log("parameter type " + parameter.GetType());

        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var info = myPropertyInfo[i];

            //RenderFieldInfo(info, "");

            //if (info.FieldType.IsEquivalentTo(typeof(string)))
            //{
            //    RenderFieldInfo(info, info.Name);
            //}

            //if (info.)
            depth++;

            if (depth < 100)
                RenderParameter(info.FieldType, ref depth);
        }
    }

    public void RenderFieldInfo(System.Reflection.FieldInfo info, string prefix)
    {
        var name = info.Name.ToString();
        var fullName = prefix + info.Name;

        if (!Foldouts.ContainsKey(fullName))
            Foldouts[fullName] = false;

        Foldouts[fullName] = EditorGUILayout.Foldout(Foldouts[fullName], name, true);

        if (Foldouts[fullName])
        {
            GUILayout.Label($"{info.FieldType} {fullName}");
            //if (info.FieldType.IsEquivalentTo(typeof(string)))
            //{
            //    var val = "";
            //    val = GetProp<string>(val, fullName);
            //}
            //else
            //{
            //    GUILayout.Label(name);
            //}
        }
    }

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

    public string GetProp(string str, string label)
    {
        GUILayout.Label(label);

        return GUILayout.TextField(str, 25);
    }

    public List<string> GetProp<T>(List<string> str, string label)
    {
        GUILayout.Label(label);

        for (var i = 0; i < str.Count; i++)
        {
            GetProp(str[i], "#" + i);
        }

        return str;
    }
}