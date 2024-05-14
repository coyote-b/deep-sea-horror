using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTreeSystem
{
    public abstract class BehaviourTree : MonoBehaviour
    {
        private INode _root = null;

        void Start()
        {
            _root = InitializeBehaviourTree();
        }

        void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract INode InitializeBehaviourTree();
    }
}
