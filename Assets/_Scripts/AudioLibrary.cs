using UnityEngine;

namespace _Scripts
{
    [System.Serializable]
    public struct Track 
    {
        public string trackName;
        public AudioClip[] clip;
    }
    public class AudioLibrary : MonoBehaviour
    {
        [SerializeField] private Track[] tracks;

        public AudioClip GetClipFromName(string clipName)
        {
            foreach (var track in tracks)
            {
                if (track.trackName == clipName)
                {
                    if (track.clip.Length > 1)
                    {
                        return track.clip[Random.Range(0,track.clip.Length)];
                    }
                    
                    return track.clip[0];
                }
            }

            return null;
        }
    }
}