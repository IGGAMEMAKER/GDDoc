using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalListManager : MonoBehaviour
{
    bool isActive = false;

    List<Goal> Goals;

    public GoalListView GoalListView;
    public ScrollRect scrollRect;

    public Text Label;
    string topic;

    // Use this for initialization
    void Start()
    {
        Goals = new List<Goal>();
        Goals.Add(new Goal("Strong Goal", "Descr"));

        topic = Label.text;

        GoalListView.Initialize(Goals);
    }

    public void AddGoal()
    {
        GoalListView.AddGoal(new Goal());

        scrollRect.horizontalNormalizedPosition = 0;

        Label.text = topic + " (" + Goals.Count + " goals)";
    }


    void CheckQuitApplication()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            // https://answers.unity.com/questions/10808/how-to-force-applicationquit-in-web-player-and-edi.html

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    private void Update()
    {
        CheckQuitApplication();
    }

    //void OnGUI()
    //{
    //    int xCenter = (Screen.width / 2);
    //    int yCenter = (Screen.height / 2);
    //    int width = 400;
    //    int height = 120;

    //    GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
    //    fontSize.fontSize = 32;

    //    if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Return to first scene", fontSize))
    //        Debug.Log("Clicked the BUTTON");
    //}
}