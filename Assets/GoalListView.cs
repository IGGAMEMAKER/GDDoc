using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalListView : MonoBehaviour {
    List<Goal> Goals;
    List<GameObject> Views;

    public GameObject GoalPrefab;

    public void Initialize(List<Goal> goals)
    {
        Views = new List<GameObject>();

        Goals = goals;

        for (var i = 0; i < Goals.Count; i++)
            SpawnGoal(goals[i]);
    }

    internal void AddGoal(Goal goal)
    {
        Goals.Add(goal);
        SpawnGoal(goal);
    }

    void SpawnGoal(Goal goal)
    {
        GameObject obj = Instantiate(GoalPrefab, transform, false);
        obj.GetComponent<GoalView>().SetData(goal);
        obj.transform.SetSiblingIndex(0);

        Views.Add(obj);
    }
}
