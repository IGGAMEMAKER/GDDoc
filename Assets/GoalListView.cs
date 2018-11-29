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

        UpdatePositions();
    }

    internal void AddGoal(Goal goal)
    {
        Goals.Add(goal);
        SpawnGoal(goal);

        UpdatePositions();
    }

    void UpdatePositions()
    {
        for (var i = 0; i < Views.Count; i++)
            Views[i].transform.localPosition = new Vector3((Views.Count - i) * 225, 0, 0);
    }

    void SpawnGoal(Goal goal)
    {
        GameObject obj = Instantiate(GoalPrefab, transform, false);
        obj.GetComponent<GoalView>().SetData(goal);
        obj.transform.SetSiblingIndex(0);

        Views.Add(obj);
    }
}
