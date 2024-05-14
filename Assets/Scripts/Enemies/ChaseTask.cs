using BehaviourTreeSystem;
using UnityEngine;

public class ChaseTask : INode
{
    private const string TARGET = "target";

    private NodeData _data;
    private SwimMovement _swimMovement;
    private Transform _target = null;
    Vector2 _direction = Vector2.zero;

    public INode Parent { get; set; }

    public NodeData Data => _data;

    public ChaseTask(SwimMovement swimMovement)
    {
        _data = new NodeData(this);

        _swimMovement = swimMovement;
    }

    public NodeState Evaluate()
    {
        _target = (Transform)_data.GetData(TARGET);

        if (Vector2.Distance(_swimMovement.transform.position, _target.position) > _swimMovement.StoppingDistance)
        {
            _direction = (_target.position - _swimMovement.transform.position).normalized;
            _swimMovement.Boost(_direction);
        }

        return NodeState.Active;
    }
}
