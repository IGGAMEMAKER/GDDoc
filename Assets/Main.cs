using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------------------------------------

public class GameLoop
{
    public string Name;
    public List<GameAction> GameActions;
}

public class GameAction
{
    public string Name;
    public int TimeBeforeRepeat; // in seconds
}

public class Main : MonoBehaviour
{
    // Loop
    // is List of actions
    // has it's name

    // Loops run in parallel

    // Action
    // has name of action
    // time before repeat

    public List<GameLoop> GameLoops;
    public List<GameObject> LoopObjects;
    public GameObject GameLoopPrefab;

    public GameObject LoopContainer;

    int SelectedLoopID = -2;
    public bool IsSelected(int Id)
    {
        return Id == SelectedLoopID;
    }

    private void Start()
    {
        GameLoops = new List<GameLoop>();

        AddLoop(new GameLoop { Name = "Core Loop", GameActions = new List<GameAction> { new GameAction { Name = "Action1", TimeBeforeRepeat = 5 } } });
    }

    public void AddLoop(GameLoop gameLoop)
    {
        GameLoops.Add(gameLoop);
    }

    public void RemoveLoop(int index)
    {
        GameLoops.RemoveAt(index);
    }

    void Draw()
    {
        RenderLoops();
    }

    void RenderLoops()
    {
        for (var i = 0; i < GameLoops.Count; i++)
        {
            var loop = GameLoops[i];

            if (i >= LoopObjects.Count)
            {
                LoopObjects.Add(Instantiate(GameLoopPrefab, LoopContainer.transform));
            }

            var obj = LoopObjects[i];

            obj.transform.localPosition = new Vector3(i * 150, 0, 0);

            var view = obj.GetComponent<GameLoopView>();

            view.LoopID = i;
            view.Draw();
        }
    }

    public void SelectGameLoop(int id)
    {
        SelectedLoopID = id;
    }

    void Update()
    {
        // render loops each 300ms

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            AddLoop(new GameLoop { GameActions = new List<GameAction>(), Name = "New Loop " + GameLoops.Count });

            RenderLoops();
        }
    }
}
