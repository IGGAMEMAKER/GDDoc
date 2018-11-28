using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalListView : MonoBehaviour {
    List<Goal> Goals;
    List<GameObject> Views;

    public GameObject GoalPrefab;

	// Use this for initialization
	void Start () {
        Views = new List<GameObject>();
	}

    public void Initialize(List<Goal> goals)
    {
        Goals = goals;

        for (var i = 0; i < goals.Count; i++)
        {
            GameObject obj = Instantiate(GoalPrefab, transform, false);
            obj.transform.localPosition = new Vector3(-i * 100, 0, 0);
            Views.Add(obj);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
