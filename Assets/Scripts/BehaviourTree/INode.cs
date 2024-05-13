using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public interface INode
    {
        public INode Parent { get; set; }
        public NodeData Data { get; }

        NodeState Evaluate();
    }
}