using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeScript : MonoBehaviour, IPointerClickHandler
{
    TNode tree;
    TNode node;
    GameObject nodePrefab;
    bool selected;

    TreeScript TreeScript;

    internal void SetData(TNode node, TNode tree, GameObject prefab)
    {
        this.node = node;
        this.tree = tree;
        this.nodePrefab = prefab;

        //selected = true;
        Render();
    }

    void Render()
    {
        GetComponentInChildren<Text>().text = node.Text;
        ToggleColor();
    }

    internal void Select()
    {
        selected = true;

        ToggleColor();
    }

    internal void Deselect()
    {
        selected = false;

        ToggleColor();
    }

    // Use this for initialization
    void Start () {
        TreeScript = GameObject.Find("Tree").GetComponent<TreeScript>();
    }

    void ToggleColor()
    {
        GetComponentInChildren<Text>().color = selected ? Color.white : Color.black;
    }

    void CheckKeyBoard()
    {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            if (selected)
                AddNode();
        }
    }

    private void AddNode()
    {
        int newId = TreeScript.GetNewId();
        TNode child = node.AddChild(newId);

        GameObject obj = Instantiate(nodePrefab, transform);

        TreeScript.AddNode(obj);

        int X = node.Childs.Count * 100;
        int Y = -100;

        obj.transform.Translate(new Vector3(X, Y, 0), Space.Self);
        obj.GetComponent<NodeScript>().SetData(child, tree, nodePrefab);
    }

    void Update()
    {
        CheckKeyBoard();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        TreeScript.OnNodeSelected(gameObject);
        //GameObject.Find("Tree").GetComponent<TreeScript>().OnNodeSelected(gameObject, node);
        selected = true; // eventData.hovered.Contains(gameObject);

        ToggleColor();
    }
}
