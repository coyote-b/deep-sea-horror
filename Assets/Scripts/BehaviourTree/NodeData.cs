using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTreeSystem
{
    public enum NodeState
    {
        Active,
        Success,
        Failure
    }

    public class NodeData
    {
        private INode _node;
        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();
        private List<INode> _children = new List<INode>();

        public NodeState State { get; set; }
        public List<INode> Children { get => _children; }

        public NodeData(INode node)
        {
            _node = node;
        }

        public NodeData(INode node, List<INode> children)
        {
            _node = node;
            children.ForEach((node) => Attach(node));
        }

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            if (_dataContext.ContainsKey(key)) 
                return _dataContext[key];

            INode currentNode = _node.Parent;

            while (currentNode != null)
            {
                object value = currentNode.Data.GetData(key);

                if (value != null) 
                    return value;

                currentNode = currentNode.Parent;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            INode currentNode = _node.Parent;

            while (currentNode != null)
            {
                bool dataCleared = currentNode.Data.ClearData(key);

                if (dataCleared)
                    return true;

                currentNode = currentNode.Parent;
            }

            return false;
        }

        private void Attach(INode node)
        {
            node.Parent = _node;
            _children.Add(node);
        }
    }
}