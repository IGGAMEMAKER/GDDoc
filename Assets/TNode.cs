using System.Collections.Generic;

public class TNode
{
    List<TNode> childs;
    private readonly int id;

    public string Text;
    public int Id { get { return id; } }

    public TNode(int id)
    {
        childs = new List<TNode>();
        Text = "Node";
        this.id = id;
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

    public void AddChild(int id)
    {
        childs.Add(new TNode(id));
    }
}
