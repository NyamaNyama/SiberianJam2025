using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Scripts
{
    public class SliderSaveLoad : MonoBehaviour
    {
        [SerializeField] private string sliderName;
        [SerializeField] private AudioMixer audioMixer;
        private Slider _slider;
        private void Awake()
        {
            sliderName += "Volume";
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(ChangeVolume);
        }

        private void Start()
        {
            Load();
        }

        private void ChangeVolume(float volume)
        {
            float fixVolume = Mathf.Log10(volume) * 20;
            audioMixer.SetFloat(sliderName, fixVolume);
            PlayerPrefs.SetFloat(sliderName,volume);
            PlayerPrefs.Save();
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey(sliderName))
            {
                _slider.value = PlayerPrefs.GetFloat(sliderName);
            }
            else
            {
                PlayerPrefs.SetFloat(sliderName,_slider.value);
            }
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(ChangeVolume);
        }
    }
}