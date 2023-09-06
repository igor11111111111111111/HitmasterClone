using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HitmasterClone
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private int _startSize = 10;
        private Transform _parent;
        private T _prefab;
        private List<T> _subjects;

        public ObjectPool(T prefab, Transform parent)
        {
            _subjects = new List<T>();
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < _startSize; i++)
            {
                Create();
            }
        }
         
        public T Get()
        {
            T subject = null;
            subject = _subjects.FirstOrDefault(b => b != null && b.gameObject.activeInHierarchy == false);

            if (subject == null)
            {
                subject = Create();
            }
            subject.gameObject.SetActive(true);

            return subject;
        }

        private T Create()
        {
            var subject = Object.Instantiate(_prefab, _parent);
            subject.gameObject.SetActive(false);
            _subjects.Add(subject);
            return subject;
        }
    }
}

