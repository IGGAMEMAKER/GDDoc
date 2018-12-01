using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject GoalMenu;
    public GameObject VisionMenu;

    Dictionary<Menu, GameObject> Menues;

    enum Menu
    {
        Vision,
        Goal,
    }

	// Use this for initialization
	void Start () {
        Menues = new Dictionary<Menu, GameObject>();

        Menues[Menu.Goal] = GoalMenu;
        Menues[Menu.Vision] = VisionMenu;

        GoalMenu.transform.localPosition = Vector3.zero;
        VisionMenu.transform.localPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            GoalMenu.SetActive(true);

            VisionMenu.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.F2))
        {
            VisionMenu.SetActive(true);

            GoalMenu.SetActive(false);
        }
	}
}
