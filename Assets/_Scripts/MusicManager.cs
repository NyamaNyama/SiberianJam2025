using System.Collections;
using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof( AudioLibrary))]
    public class MusicManager : Singleton<MusicManager>
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioLibrary musicLibrary;
        
        public void PlayMusic(string musicName, float fadeDuration = 0.5f)
        {
            StartCoroutine(AnimateMusicCrossFade(musicLibrary.GetClipFromName(musicName),
                fadeDuration));
        }
        
        IEnumerator AnimateMusicCrossFade(AudioClip nextTrack, float fadeDuration = 0.5f)
        {
            float percent = 0;
            while (percent < 1)
            {
                percent += Time.deltaTime * 1 / fadeDuration;
                musicSource.volume = Mathf.Lerp(1f, 0, percent);
                yield return null;
            }

            musicSource.clip = nextTrack;
            musicSource.Play();
            percent = 0;
            while (percent < 1)
            {
                percent += Time.deltaTime * 1 / fadeDuration;
                musicSource.volume = Mathf.Lerp(0, 1f, percent);
                yield return null;
            }
        }
    }
}