using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script

public partial class GDDoc
{
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

    void Badge(string label, int indent = 1)
    {
        var boldText = new GUIStyle();
        boldText.richText = true;
        boldText.fontSize = 24;

        var indentation = new string(' ', indent * 4);

        GUILayout.Label($"<b>{indentation + label}</b>", boldText);
    }

    void Space(int space = 15)
    {
        GUILayout.Space(space);
    }

    public string InputProperty(string str, string label, int depth = 0)
    {
        var boldText = GUI.skin.textField;
        //boldText.richText = true;

        var indentation = new string(' ', depth * 4);

        //Label(label, depth);
        return EditorGUILayout.TextField($"{indentation + label}", str, boldText);
        return GUILayout.TextField(str, 25);
    }
}