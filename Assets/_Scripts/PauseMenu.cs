using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuWindow;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuWindow.activeSelf == true)
                {
                    Continue();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            menuWindow.SetActive(true);
        }

        public void Continue()
        {
            Time.timeScale = 1f;
            menuWindow.SetActive(false);
        }

        public void MainMenu()
        {
            Continue();
            LoadSceneManager.Instance.LoadScene("Menu");
        }
    }
}