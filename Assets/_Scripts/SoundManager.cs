using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof(AudioLibrary))] 
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioLibrary soundLibrary;
        [SerializeField] private AudioSource soundSource;

        public void PlaySound3D(AudioClip clip, Vector3 pos)
        {
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip,pos);
            }
        }

        public void PlaySound3D(string soundName, Vector3 pos)
        {
            PlaySound3D(soundLibrary.GetClipFromName(soundName),pos);
        }
        
        public void PlaySound3D(string soundName)
        {
            soundSource.PlayOneShot(soundLibrary.GetClipFromName(soundName));
        }
    }
}