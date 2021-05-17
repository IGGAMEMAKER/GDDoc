using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script

public class GDDoc : EditorWindow
{
    public Dictionary<string, bool> Foldouts = new Dictionary<string, bool>();
    public Vector2 scrollView = Vector2.zero;

    private void OnGUI()
    {
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

        scrollView = EditorGUILayout.BeginScrollView(scrollView);

        int counter = 0;

        GUILayout.Space(25);

        RenderParameter(project, ref counter, 1);

        GUILayout.Space(25);

        EditorGUILayout.EndScrollView();
    }

    void Describe(object value)
    {
        var jsonString = JsonUtility.ToJson(value, true);

        GUILayout.Label($"{name} ({value.GetType()}) \n{jsonString}");
    }

    void Label(string label, int indent = 0)
    {
        var boldText = new GUIStyle();
        boldText.richText = true;

        var indentation = new string(' ', indent * 4);

        GUILayout.Label(indentation + label, boldText);
    }

    public void RenderParameter<T>(T parameter, ref int counter, int depth)
    {
        if (parameter == null)
            return;

        var parameterType = parameter.GetType();
        //var myPropertyInfo = typeof(T).GetFields();

        var myPropertyInfo = parameterType.GetFields();

        Debug.Log($"CHECKING ({myPropertyInfo.Length}) {parameter.ToString()}"); // name=<b>{parameterType.Name}</b>

        // is string
        if (parameterType.IsEquivalentTo(typeof(string)))
        {
            //Label("String: " + parameter.ToString());
            InputProperty(parameter.ToString(), "", depth); // parameter.GetType().Name
            return;
        }

        // is List
        //if (parameterType.IsEquivalentTo(typeof(List<T>)))
        if (parameter.ToString().Contains("System.Collections.Generic.List"))
        {
            Label("List", depth); //  + parameterType.ToString()
            return;
        }

        // is Dictionary

        // is Complex type
        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var info = myPropertyInfo[i];

            counter++;

            if (counter > 540)
                break;

            var name = info.Name.ToString();
            var fieldType = info.FieldType;

            EditorGUILayout.BeginFoldoutHeaderGroup(true, $"{name} ({myPropertyInfo.Length})");

            var value = GetPropValue(parameter, name);
            var jsonString = JsonUtility.ToJson(value, true);


            Label($"<b>{name}</b> ({fieldType})", depth);
            //Label($"{name} ({fieldType})\n{jsonString}");

            RenderParameter(value, ref counter, depth + 1);

            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        GUILayout.Space(15);
    }

    static T GetJSONDataFromFile<T>(string jsonString)
    {
        try
        {
            var obj = JsonUtility.FromJson<T>(jsonString);

            if (obj != null)
                return obj;
        }
        catch
        {
            // This is handled in GetCountableAssetsFromFile function
        }

        return (T)Activator.CreateInstance(typeof(T));
    }

    public static object GetPropValue(object src, string propName)
    {
        // https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection
        //Debug.Log("Trying to get property " + propName + " from object " + src);

        var value = src.GetType().GetField(propName).GetValue(src);

        return value;
    }

    public static object GetProperty(object src, string propName)
    {
        // https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection
        //Debug.Log("Trying to get property " + propName + " from object " + src);

        var value = src.GetType().GetProperty(propName).GetValue(src);

        return value;
    }

    public string InputProperty(string str, string label, int depth = 0)
    {
        Label(label, depth);

        return GUILayout.TextField(str, 25);
    }

    public List<string> GetProp<T>(List<string> str, string label)
    {
        GUILayout.Label(label);

        for (var i = 0; i < str.Count; i++)
        {
            InputProperty(str[i], "#" + i);
        }

        return str;
    }
}