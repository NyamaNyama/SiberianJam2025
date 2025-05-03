using System;
using _Scripts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    private void Start()
    {
        MusicManager.Instance.PlayMusic("Menu");
    }

    public void Play()
    {
        LoadSceneManager.Instance.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
