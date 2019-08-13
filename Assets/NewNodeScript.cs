using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewNodeScript : MonoBehaviour
    , IPointerClickHandler
    //, IPointerExitHandler
    //, IPoin
{
    [Tooltip("Only set this")]
    public GameObject NewNodePrefab;
    public GameObject Canvas;

    [Tooltip("These will be set automatically")]
    public NewNodeScript Next;
    public NewNodeScript Previous;

    bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
            CheckInput();
    }

    void AddNextNode()
    {
        Next = SpawnNewNode();
        Next.gameObject.transform.position = transform.position + new Vector3(100, 0, 0);

        SetSelected(false);
        Next.SetSelected(true);
    }

    void AddPreviousNode()
    {

    }

    void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
                AddPreviousNode();
            else
                AddNextNode();
        }
    }

    NewNodeScript SpawnNewNode()
    {
        var n = Instantiate(NewNodePrefab, Canvas.transform).GetComponent<NewNodeScript>();

        n.NewNodePrefab = NewNodePrefab;
        n.Canvas = Canvas;

        n.Previous = this;

        return n;
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;

        var scale = selected ? 1.2f : 1f;
        transform.localScale = new Vector3(scale, scale, 1);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SetSelected(true);
    }

    //void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    //{
    //    SetSelected(false);
    //}
}
