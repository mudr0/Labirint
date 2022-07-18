using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint {
    public class ListExecuteObjects : IEnumerable, IEnumerator
    {
        private IExecute[] _interactiveObjects;
        private int _index = -1;

        public int Length => _interactiveObjects.Length;
        public object Current => _interactiveObjects[_index];
        public IExecute CurrentExecute => _interactiveObjects[_index];

        public ListExecuteObjects() 
        {
            
        }

        public void AddExecuteObject(IExecute execute)
        {
            if(_interactiveObjects == null)
            {
                _interactiveObjects = new IExecute[] { execute };
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if(_index == Length - 1)
            {
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
