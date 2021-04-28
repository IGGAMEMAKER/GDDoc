using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLoopView : MonoBehaviour
    , IPointerClickHandler
    //, IPointerExitHandler
{
    Main Main;

    public Text Name;
    public GameLoop GameLoop => Main.GameLoops[LoopID];
    public List<GameAction> actions => GameLoop.GameActions;

    bool isSelected => Main.IsSelected(LoopID);

    public List<GameObject> Actions;
    public GameObject GameActionPrefab;

    public GameObject ActionContainer;

    [HideInInspector]
    public int LoopID = -1;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Name.fontStyle = FontStyle.Bold;
    }

    public void Draw()
    {
        if (LoopID >= 0)
        {
            Name.text = GameLoop.Name;

            RenderActions();
        }
    }

    void RenderActions()
    {
        for (var i = 0; i < actions.Count; i++)
        {
            var loop = actions[i];

            if (i >= Actions.Count)
            {
                Actions.Add(Instantiate(GameActionPrefab, ActionContainer.transform));
            }

            var obj = Actions[i];

            obj.transform.localPosition = new Vector3(0, i * 150, 0);

            //var view = obj.GetComponent<GameLoopView>();

            //view.LoopID = i;
            //view.Draw();
        }
    }

    void Start()
    {
        Main = FindObjectOfType<Main>();

        Actions = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            var actionId = actions.Count;

            actions.Add(new GameAction { Name = "Game Action " + actionId, TimeBeforeRepeat = 10 });

            RenderActions();
        }
    }
}
