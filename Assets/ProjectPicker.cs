using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectPicker : MonoBehaviour
{
    public Project Project;

    [MenuItem("GDD/Menu")]
    static void Init()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(GDDoc));
        window.Show();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
