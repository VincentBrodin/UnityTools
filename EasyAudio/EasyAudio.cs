using UnityEngine;

namespace UnityTools.EasyAudio
{
    [CreateAssetMenu(fileName = "New Audio", menuName = "Easy Tools/Audio/New Audio", order = 0)]
    public class EasyAudio : ScriptableObject
    {
        public string audioName;
        public AudioClip audioClip;
        public float volume;
        public Vector2 pitchRange;
    }
}