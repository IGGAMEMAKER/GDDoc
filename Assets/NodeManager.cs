using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NodeInfo
{
    public int ID;
    public string Name;
    public string Trigger;
    public string Consequence;

    // for different
    public Color Color;
}

public class Node
{
    public int NodeID;
    public List<Node> Daughters = new List<Node>();

    public Node GetByNodeId(int nodeID)
    {
        if (NodeID == nodeID)
            return this;

        foreach (var d in Daughters)
        {
            if (GetByNodeId(nodeID) != null)
                return GetByNodeId(nodeID);
        }

        return null;
    }
}

public class NodeManager : MonoBehaviour
{
    public GameObject NodePrefab;
    public List<GameObject> NodeObjects;

    public List<NodeInfo> Nodes;
    public Node NodeTree;

    // Start is called before the first frame update
    void Start()
    {
        NodeObjects = new List<GameObject>();

        Nodes = new List<NodeInfo>();
        NodeTree = new Node
        {
            NodeID = 0
        };
        AddNode("Name", "Consequence", "Trigger", Color.black);


        for (var i = 0; i < 30; i++)
        {
            var o = Instantiate(NodePrefab);
            o.SetActive(false);

            NodeObjects.Add(o);
        }
    }

    public int AddNode(string Name, string Consequence, string Trigger, Color color)
    {
        var id = Nodes.Count;

        Nodes.Add(new NodeInfo
        {
            Color = color,
            Consequence = Consequence,
            ID = id,
            Name = Name,
            Trigger = Trigger
        });

        return id;
    }

    void Draw()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
