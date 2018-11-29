using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalListManager : MonoBehaviour {
    bool isActive = false;

    List<Goal> Goals;

    public GoalListView GoalListView;
    public ScrollRect scrollRect;

    public Text Label;
    string topic;

    // Use this for initialization
    void Start () {
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
}
