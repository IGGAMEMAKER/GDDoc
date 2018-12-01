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

        GoalMenu.transform.localPosition = Vector3.zero;
        VisionMenu.transform.localPosition = Vector3.zero;
        MarketingMenu.transform.localPosition = Vector3.zero;
        GameplayMenu.transform.localPosition = Vector3.zero;
	}

    void DisableMenues()
    {
        foreach (var menu in Menues.Values)
            menu.SetActive(false);
    }

    void EnableMenu(GameObject menu)
    {
        DisableMenues();

        menu.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F1))
            EnableMenu(GoalMenu);

        if (Input.GetKeyUp(KeyCode.F2))
            EnableMenu(VisionMenu);

        if (Input.GetKeyUp(KeyCode.F3))
            EnableMenu(MarketingMenu);
        
        if (Input.GetKeyUp(KeyCode.F4))
            EnableMenu(GameplayMenu);
	}
}
