using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalListManager : MonoBehaviour {
    bool isActive = false;

    List<Goal> Goals;

    public GoalListView GoalListView;

	// Use this for initialization
	void Start () {
        Goals = new List<Goal>();
        Goals.Add(new Goal("Strong Goal", "Descr"));

        GoalListView.Initialize(Goals);
    }

    public void AddGoal()
    {
        GoalListView.AddGoal(new Goal());
    }
}
