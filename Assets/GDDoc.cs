using System;
using System.Collections;
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
        var community = new Community
        {
            Players = new List<Player> { new Player { Name = "Name", Description = "asda" }  },
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

        RenderParameter(project, ref counter, 1);
        //RenderParameter(project.WhatFeelingsDoYouCreate, ref counter, 1);
        //RenderParameter(project.WhatsFun, ref counter, 1);
        //RenderParameter(project.WhyThisWillWork, ref counter, 1);

        //RenderParameter(project.Community, ref counter, 1);
        //RenderParameter(project.Idea, ref counter, 1);

        //RenderParameter(project.Release, ref counter, 1);
        //RenderParameter(project.Risks, ref counter, 1);

        Space(25);

        EditorGUILayout.EndScrollView();
    }

    public void RenderParameter<T>(T parameter, ref int counter, int depth)
    {
        if (parameter == null)
            return;

        var parameterType = parameter.GetType();

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
        if (parameter.ToString().Contains("System.Collections.Generic.List"))
        {
            var enumerable = parameter as IEnumerable;

            int cnt = 0;
            foreach (var item in enumerable)
            {
                if (cnt == 0)
                    Label("List", depth); //  + parameterType.ToString()

                cnt++;
            }

            foreach (var item in enumerable)
            {
                RenderParameter(item, ref counter, depth + 1);
            }

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

            var value = GetField(parameter, name);
            var jsonString = JsonUtility.ToJson(value, true);


            Label($"<b>{depth} {name}</b> ({GetPrettyFieldType(info)})", depth); // fieldType
            //Label($"{name} ({fieldType})\n{jsonString}");

            RenderParameter(value, ref counter, depth + 1);
        }

        GUILayout.Space(15);
    }

    static string GetPrettyFieldType(object obj)
    {
        if (isString(obj.GetType()))
        {
            return "string";
        }

        if (isList(obj))
        {
            return "List";
        }

        return obj.GetType().ToString();
    }

    static bool isString(Type type) => type.IsEquivalentTo(typeof(string));
    static bool isList(object type) => type.ToString().Contains("System.Collections.Generic.List");

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

    public static object GetField(object src, string propName)
    {
        // https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection
        //Debug.Log("Trying to get property " + propName + " from object " + src);

        var value = src.GetType().GetField(propName).GetValue(src);

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

    void Space(int space = 15)
    {
        GUILayout.Space(space);
    }
}