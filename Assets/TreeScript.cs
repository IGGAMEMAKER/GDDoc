using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    public GameObject TreeNode;

    public TNode tree;
    GameObject Root;

    List<GameObject> Nodes;

    int nodes = 0;

    // Use this for initialization
    void Start () {
        Nodes = new List<GameObject>();
        tree = new TNode(nodes++);

        Nodes.Add(GameObject.Find("Node"));
        Nodes[0].GetComponent<NodeScript>().SetData(tree, tree, TreeNode);
        Nodes[0].GetComponent<NodeScript>().Select();

    }

    public int GetNewId ()
    {
        return nodes++;
    }

    public void OnNodeSelected(GameObject obj)
    {
        Debug.Log("OnNodeSelected");

        for (var i = 0; i < Nodes.Count; i++)
            Nodes[i].GetComponent<NodeScript>().Deselect();
    }

    internal void AddNode(GameObject obj)
    {
        Nodes.Add(obj);
    }
}
