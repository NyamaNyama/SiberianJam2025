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
                        GameObject newobj = new GameObject(typeof(T).ToString());
                        newobj.AddComponent<T>();
                        DontDestroyOnLoad(newobj);
                    }
                }

                return _instance;
            }
        }
    }
}