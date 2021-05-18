using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script

public partial class GDDoc
{
    public void RenderParameter<T>(T parameter, ref int counter, int depth, string propertyName = "")
    {
        if (parameter == null)
            return;

        var parameterType = parameter.GetType();

        // string
        if (IsString(parameterType))
        {
            InputProperty(parameter.ToString(), propertyName, depth); // parameter.GetType().Name

            return;
        }

        // list
        if (IsList(parameter))
        {
            var enumerable = parameter as IEnumerable;

            int cnt = 0;
            foreach (var item in enumerable)
            {
                cnt++;
            }

            if (cnt > 0)
            {
                Label($"List ({cnt})", depth); //  + parameterType.ToString()
            }

            foreach (var item in enumerable)
            {
                RenderParameter(item, ref counter, depth + 1);
                Space(5);
            }

            if (cnt != 0)
                Space(20);

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

            if (!IsString(info.FieldType))
                Label($"<b>{name}</b> ({GetPrettyFieldType(info.FieldType)})", depth);

            RenderParameter(value, ref counter, depth + 1, name);
        }

        Space(10);
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
}