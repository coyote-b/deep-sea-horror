using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTreeSystem
{
    public class Sequencer : INode
    {
        private NodeData _data;

        public INode Parent { get; set; }

        public NodeData Data => _data;

        public Sequencer(List<INode> children)
        {
            _data = new NodeData(this, children);
        }

        public NodeState Evaluate()
        {
            bool isAnyChildActive = false;

            foreach (INode node in _data.Children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Failure:
                        _data.State = NodeState.Failure;
                        return _data.State;
                    case NodeState.Success:
                        continue;
                    case NodeState.Active:
                        isAnyChildActive = true;
                        continue;
                    default:
                        _data.State = NodeState.Success;
                        return _data.State;
                }
            }

            _data.State = isAnyChildActive ? NodeState.Active : NodeState.Success;
            return _data.State;
        }
    }
}