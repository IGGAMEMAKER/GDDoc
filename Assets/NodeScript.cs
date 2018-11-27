using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeScript : MonoBehaviour, IPointerClickHandler
{
    TNode tree;
    TNode node;
    GameObject nodePrefab;
    bool selected;

    List<GameObject> childs;

    TreeScript TreeScript;

    internal void SetData(TNode node, TNode tree, GameObject prefab)
    {
        this.node = node;
        this.tree = tree;
        this.nodePrefab = prefab;

        Render();
    }

    void Render()
    {
        GetComponentInChildren<Text>().text = node.Id.ToString();
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
        childs = new List<GameObject>();
    }

    void ToggleColor()
    {
        GetComponentInChildren<Text>().color = selected ? Color.white : Color.black;
    }

    void CheckKeyBoard()
    {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
            AddNode();

        if (Input.GetKeyDown(KeyCode.DownArrow))
            SelectMiddleChild();
    }

    private void SelectMiddleChild()
    {
        if (childs.Count > 0)
        {
            Deselect();
            childs[childs.Count / 2].GetComponent<NodeScript>().Select();
        }
    }

    private void AddNode()
    {
        int newId = TreeScript.GetNewId();
        TNode child = node.AddChild(newId);

        GameObject obj = Instantiate(nodePrefab, transform);

        TreeScript.AddNode(obj);
        childs.Add(obj);

        obj.transform.Translate(new Vector3(0, -100, 0), Space.Self);
        obj.GetComponent<NodeScript>().SetData(child, tree, nodePrefab);

        ResizeChilds();
    }

    private void ResizeChilds()
    {
        int count = childs.Count;
        for (var i = 0; i < count; i++)
        {
            int width = 100;
            float X = (i - (count - 1) / 2f) * width; // -1 because count is always > 1

            childs[i].transform.localPosition = new Vector3(X, -100, 0);
        }
    }

    void Update()
    {
        if (selected)
            CheckKeyBoard();

        ResizeChilds();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        TreeScript.OnNodeSelected(gameObject);
        //GameObject.Find("Tree").GetComponent<TreeScript>().OnNodeSelected(gameObject, node);
        selected = true; // eventData.hovered.Contains(gameObject);

        ToggleColor();
    }
}
