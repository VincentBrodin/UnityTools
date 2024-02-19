using System.Collections.Generic;
using UnityEngine;

namespace UnityTools.EasyAudio
{
    public class EasyAudioManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public static EasyAudioManager Singleton { get; private set; }
        public Dictionary<string, UnityTools.EasyAudio.EasyAudio> Audios{ get; private set; } = new();
        private const string ResourcePath = "Audios";
        
        private void Awake(){
            if (Singleton == null || Singleton != this){
                Singleton = this;
            }
            else{
                Destroy(gameObject);
            }
            
            //Get all animations from resources
            
            UnityTools.EasyAudio.EasyAudio[] audios = Resources.LoadAll<UnityTools.EasyAudio.EasyAudio>(ResourcePath);
            foreach (UnityTools.EasyAudio.EasyAudio eAudio in audios){
                Audios.Add(eAudio.audioName, eAudio);
            }
        }

        public UnityTools.EasyAudio.EasyAudio GetAudio(string audioName){
            return Audios[audioName];
        }
        
        public void PlayAudio(string audioName){
            UnityTools.EasyAudio.EasyAudio easyAudio = GetAudio(audioName);
            PlayAudio(easyAudio);
        }
        
        public void PlayAudio(UnityTools.EasyAudio.EasyAudio easyAudio){
            audioSource.clip = easyAudio.audioClip;
            audioSource.volume = easyAudio.volume;
            audioSource.pitch = Random.Range(easyAudio.pitchRange.x, easyAudio.pitchRange.y);
            audioSource.PlayOneShot(easyAudio.audioClip);
        }
    }
}