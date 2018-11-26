using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    public GameObject TreeNode;

    public TNode tree;

    GameObject Chosen;
    TNode ChosenNode;

    int nodes = 0;

    // Use this for initialization
    void Start () {
        tree = new TNode(nodes++);
        ChosenNode = tree;

        Chosen = Instantiate(TreeNode, transform);
	}

    void AddNode()
    {
        ChosenNode.AddChild(nodes++);

        Chosen = Instantiate(TreeNode, Chosen.transform);
        Chosen.transform.Translate(new Vector3(0, -50), Space.Self);
    }

    void CheckKeyBoard()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            AddNode();
        }
    }
	
	// Update is called once per frame
	void Update () {
        CheckKeyBoard();

    }
}
