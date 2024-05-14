using BehaviourTreeSystem;
using System.Collections.Generic;
using UnityEngine;

public class RoamTask : INode
{
    private NodeData _data;

    private SwimMovement _swimMovement;

    private List<Transform> _waypoints;
    private int _currentWaypoint;

    private float _waitCounter;
    private bool _waiting = false;
    private float _waitTime;

    public INode Parent { get; set; }

    public NodeData Data => _data;

    public RoamTask(SwimMovement swimMovement, List<Transform> waypoints, float waitTime)
    {
        _data = new NodeData(this);

        _swimMovement = swimMovement;
        _waypoints = waypoints;
        _waitTime = waitTime;
    }

    public NodeState Evaluate()
    {
        _data.State = NodeState.Active;

        if (!_waiting)
        {
            Roam(_waypoints[_currentWaypoint]);
            return _data.State;
        }

        _waitCounter += Time.deltaTime;

        if (_waitCounter >= _waitTime)
        {
            _waiting = false;
        }

        return _data.State;
    }

    private void Roam(Transform waypoint)
    {
        if (Vector2.Distance(_swimMovement.transform.position, waypoint.position) < _swimMovement.StoppingDistance)
        {
            StartWaiting();
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;

            return;
        }

        Vector2 direction = (waypoint.position - _swimMovement.transform.position).normalized;
        _swimMovement.Swim(direction);
    }

    private void StartWaiting()
    {
        _waitCounter = 0;
        _waiting = true;
    }
}
