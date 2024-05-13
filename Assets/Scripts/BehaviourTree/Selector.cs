using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Selector : INode
    {
        private NodeData _data;

        public INode Parent { get; set; }

        public NodeData Data => _data;

        public Selector(List<INode> children)
        {
            _data = new NodeData(this, children);
        }

        public NodeState Evaluate()
        {
            foreach (INode node in _data.Children)
            {
                NodeState state = node.Evaluate();

                if (state == NodeState.Success || state == NodeState.Active)
                {
                    _data.State = state;
                    return _data.State;
                }
            }

            _data.State = NodeState.Failure;
            return _data.State;
        }
    }
}