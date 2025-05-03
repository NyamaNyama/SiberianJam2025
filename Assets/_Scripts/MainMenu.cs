using System;
using _Scripts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        LoadVolume();
        MusicManager.Instance.PlayMusic("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume",Mathf.Log10(volume) * 20);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MasterVolume", out float masterVolume);
        PlayerPrefs.SetFloat("MasterVolume",masterVolume);
        
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume",musicVolume);
        
        audioMixer.GetFloat("SoundVolume", out float soundVolume);
        PlayerPrefs.SetFloat("SoundVolume",soundVolume);
    }

    public void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
    }
}
