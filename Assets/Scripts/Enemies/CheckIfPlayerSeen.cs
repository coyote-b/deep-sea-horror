using BehaviourTreeSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerSeen : INode
{
    private const string TARGET = "target";

    private NodeData _data;
    private Rigidbody2D _rigidbody;

    public INode Parent { get; set; }

    public NodeData Data => _data;

    public CheckIfPlayerSeen(Rigidbody2D rigidbody)
    {
        _data = new NodeData(this);

        _rigidbody = rigidbody;
    }

    public NodeState Evaluate()
    {
        object target = _data.GetData("target");

        if (target != null)
            return NodeState.Success;
        
        List<Collider2D> collisions = new List<Collider2D>();
        _rigidbody.GetContacts(collisions);

        if (collisions.Count <= 0)
            return NodeState.Failure;

        _data.SetDataInRoot(TARGET, collisions[0].transform);

        return NodeState.Success;
    }
}
