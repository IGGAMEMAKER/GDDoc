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
                RenderParameter(project.WhyThisWillWork, ref counter, 1);
                break;
        }

        //RenderParameter(project, ref counter, 1);

        Space(25);

        EditorGUILayout.EndScrollView();
    }

    public void RenderParameter<T>(T parameter, ref int counter, int depth)
    {
        if (parameter == null)
            return;

        var parameterType = parameter.GetType();

        // string
        if (IsString(parameterType))
        {
            InputProperty(parameter.ToString(), "", depth); // parameter.GetType().Name

            return;
        }

        // list
        if (IsList(parameter))
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

        // dictionary
        if (IsDictionary(parameter))
        {
            //Label("Dictionary", depth);

            return;
        }

        // complex type
        var myPropertyInfo = parameterType.GetFields();
        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            var info = myPropertyInfo[i];

            counter++;

            var name = info.Name.ToString();
            var value = GetField(parameter, name);

            Label($"<b>{depth} {name}</b> ({GetPrettyFieldType(info.FieldType)})", depth);

            RenderParameter(value, ref counter, depth + 1);
        }

        GUILayout.Space(15);
    }

    static string GetPrettyFieldType(Type type)
    {
        if (type == typeof(string))
        {
            return "string";
        }

        if (IsDictionary(type))
        {
            return "Dictionary";
        }

        if (IsList(type))
        {
            return "List";
        }

        return type.ToString();
    }

    static bool IsString(Type type) => type.IsEquivalentTo(typeof(string));
    static bool IsList(object type) => type.ToString().Contains("System.Collections.Generic.List");
    static bool IsDictionary(object type) => type.ToString().Contains("System.Collections.Generic.Dictionary");

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

    void BigLabel(string label, int indent = 0)
    {
        var boldText = new GUIStyle();
        boldText.richText = true;
        boldText.fontSize = 42;

        var indentation = new string(' ', indent * 4);

        GUILayout.Label($"<b>{indentation + label}</b>", boldText);
    }

    void Space(int space = 15)
    {
        GUILayout.Space(space);
    }
}