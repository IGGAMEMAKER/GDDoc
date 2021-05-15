using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script

public class GDDoc : EditorWindow
{
    string test = "ghgh";

    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();
    public Vector2 scrollView = Vector2.zero;

    private void OnGUI()
    {
        //test = GetProp(test, "test");

        //EditorGUILayout.LabelField(test);

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

        Project project = new Project
        {
            WhatsFun = new List<string> { "Fun" },
            WhatFeelingsDoYouCreate = new List<Emotion> { new Emotion() },

            Audience = audience,
            Idea = idea,
            Release = release,
            WhyThisWillWork = success,

            Risks = new List<Risk>(),
        };

        //var myPropertyInfo = typeof(Project).GetFields();

        ////Debug.Log("Properties of Project are: " + myPropertyInfo.Length);

        //for (int i = 0; i < myPropertyInfo.Length; i++)
        //{
        //    var info = myPropertyInfo[i];

        //    RenderFieldInfo(info, "");
        //}

        scrollView = EditorGUILayout.BeginScrollView(scrollView);

        int depth = 0;
        //RenderParameter(idea, ref depth);

        //GUILayout.Space(25);
        RenderParameter(project, ref depth);
        GUILayout.Space(25);

        RenderParameter(project.Release, ref depth);
        //RenderParameter(typeof(Project), ref depth);


        GUILayout.Space(25);
        //RenderParameter(typeof(Project), ref depth);

        EditorGUILayout.EndScrollView();
    }

    public void RenderParameter<T>(T parameter, ref int depth)
    {
        var myPropertyInfo = typeof(T).GetFields();

        Debug.Log($"CHECKING ({myPropertyInfo.Length}) {parameter.ToString()}");

        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var info = myPropertyInfo[i];

            depth++;

            var name = info.Name.ToString();

            EditorGUILayout.BeginFoldoutHeaderGroup(true, $"{name} ({myPropertyInfo.Length})");


            var value = GetPropValue(parameter, name);
            var jsonString = JsonUtility.ToJson(value, true);

            GUILayout.Label($"{name} ({info.FieldType}) \n{jsonString}");

            RenderParameter(value, ref depth);

            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }

    public static object GetPropValue(object src, string propName)
    {
        // https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection
        Debug.Log("Trying to get property " + propName + " from object " + src);

        var value = src.GetType().GetField(propName).GetValue(src);

        return value;
    }

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