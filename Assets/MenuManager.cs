using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject GoalMenu;
    public GameObject VisionMenu;
    public GameObject MarketingMenu;
    public GameObject GameplayMenu;

    Dictionary<Menu, GameObject> Menues;

    enum Menu
    {
        Vision,
        Goal,
        Marketing,
        Gameplay
    }

	// Use this for initialization
	void Start () {
        Menues = new Dictionary<Menu, GameObject>();

        Menues[Menu.Goal] = GoalMenu;
        Menues[Menu.Vision] = VisionMenu;
        Menues[Menu.Gameplay] = GameplayMenu;
        Menues[Menu.Marketing] = MarketingMenu;

        EnableMenu(Menu.Goal);
	}

    void DisableMenues()
    {
        foreach (var menu in Menues.Values)
        {
            menu.SetActive(false);
            menu.transform.localPosition = Vector3.zero;
        }
    }

    void EnableMenu(Menu menu)
    {
        DisableMenues();

        Menues[menu].SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F1))
            EnableMenu(Menu.Goal);

        if (Input.GetKeyUp(KeyCode.F2))
            EnableMenu(Menu.Vision);

        if (Input.GetKeyUp(KeyCode.F3))
            EnableMenu(Menu.Marketing);
        
        if (Input.GetKeyUp(KeyCode.F4))
            EnableMenu(Menu.Gameplay);
	}
}
