using System;
using System.Collections.Generic;

[System.Serializable]
public class TNode
{
    private List<TNode> childs;
    private readonly int id;

    public string Text;
    public int Id { get { return id; } }

    public TNode(int id)
    {
        childs = new List<TNode>();
        Text = "Node";
        this.id = id;
    }

    public TNode GetNode(int id)
    {
        if (Id == id)
            return this;

        for (var i = 0; i < childs.Count; i++)
        {
            TNode node = childs[i].GetNode(id);

            if (node == null)
                continue;
            else
                return node;
        }

        return null;
    }

    public List<TNode> Childs
    {
        get { return childs; }
    }

    public void Remove()
    {
        foreach (var child in childs)
        {
            child.Remove();
        }
    }

    public TNode AddChild(int id)
    {
        TNode child = new TNode(id);
        childs.Add(child);

        return child;
    }
}
