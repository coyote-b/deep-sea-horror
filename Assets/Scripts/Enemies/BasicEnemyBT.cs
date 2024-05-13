using BehaviourTreeSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBT : BehaviourTree
{
    [SerializeField]
    private SwimMovement _movement;

    [SerializeField]
    private List<Transform> _waypoints;

    [SerializeField]
    private float _waitTime;

    protected override INode InitializeBehaviourTree()
    {
        INode root = new Selector(new List<INode>
        {
            new RoamTask(_movement, _waypoints, _waitTime)
        });

        return root;
    }
}
