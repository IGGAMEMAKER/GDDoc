using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalListManager : MonoBehaviour {
    bool isActive = false;

    List<Goal> Goals;

    public GameObject GoalListView;
    GoalListView listView;

	// Use this for initialization
	void Start () {
        Goals = new List<Goal>();
        Goals.Add(new Goal("Strong Goal", "Descr"));

        listView = GoalListView.GetComponent<GoalListView>();

        Render();
    }

    public void AddGoal()
    {

    }

    void Render()
    {
        listView.Initialize(Goals);
    }
}
