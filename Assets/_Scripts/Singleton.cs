using System;
using UnityEngine;

namespace _Scripts
{
    abstract public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();
                    if (_instance == null)
                    {
                        _instance = new GameObject().AddComponent<T>();
                        _instance.name = _instance.GetType().ToString();
                    }
                }

                return _instance;
            }
        }

    }
}