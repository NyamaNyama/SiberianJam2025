using System;
using UnityEngine;

namespace _Scripts
{
    public class BackToMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuWindow;
        [SerializeField] private GameObject optionsWindow;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (mainMenuWindow.activeSelf == false)
                {
                    mainMenuWindow.SetActive(true);
                    optionsWindow.SetActive(false);
                }
            }
        }
    }
}