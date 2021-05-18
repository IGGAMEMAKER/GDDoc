using System;
using System.Collections;
using System.Reflection;

// https://stackoverflow.com/questions/55407676/how-can-i-draw-a-list-and-all-its-items-in-inspector-editor-script

public partial class GDDoc
{
    public void RenderParameter<T>(T parameter, string propertyName = "", int depth = 1)
    {
        if (parameter == null)
            return;

        var parameterType = parameter.GetType();

        if (depth == 1 && IsComplexType(parameter))
        {
            Label($"{GetPrettyFieldType(parameter.GetType())}", depth);
        }

        // string
        if (IsString(parameterType))
        {
            InputProperty(parameter.ToString(), propertyName, depth); // parameter.GetType().Name
            return;
        }

        // list
        if (IsList(parameter))
        {
            RenderList(parameter, depth);
            return;
        }

        // dictionary
        if (IsDictionary(parameter))
        {
            Label("Dictionary", depth);
            return;
        }

        // complex type
        var fields = parameterType.GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            var info = fields[i];

            RenderProperty(parameter, info, depth);
        }

        Space(10);
    }

    void RenderProperty<T>(T parameter, FieldInfo info, int depth = 1)
    {
        var name = info.Name.ToString();
        var value = GetField(parameter, name);

        if (!IsString(info.FieldType))
            Label($"<b>{name}</b> ({GetPrettyFieldType(info.FieldType)})", depth);

        counter++;

        RenderParameter(value, name, depth + 1);
    }

    void RenderList<T>(T parameter, int depth = 1)
    {
        var enumerable = parameter as IEnumerable;

        int cnt = 0;
        foreach (var item in enumerable)
            cnt++;

        if (cnt > 0)
            Label($"List ({cnt})", depth); //  + parameterType.ToString()

        foreach (var item in enumerable)
        {
            RenderParameter(item, item.ToString(), depth + 1);
            Space(1);
        }

        if (cnt != 0)
            Space(20);
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

    static bool IsComplexType<T>(T obj) => !(IsString(obj.GetType()));

    public static object GetField(object src, string propName)
    {
        // https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection
        //Debug.Log("Trying to get property " + propName + " from object " + src);

        var value = src.GetType().GetField(propName).GetValue(src);

        return value;
    }
}