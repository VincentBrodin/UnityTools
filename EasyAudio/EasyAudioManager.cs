using System.Collections.Generic;
using UnityEngine;

namespace EasyAudio
{
    public class EasyAudioManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public static EasyAudioManager Singleton { get; private set; }
        public Dictionary<string, EasyAudio> Audios{ get; private set; } = new();
        private const string ResourcePath = "Audios";
        
        private void Awake(){
            if (Singleton == null || Singleton != this){
                Singleton = this;
            }
            else{
                Destroy(gameObject);
            }
            
            //Get all animations from resources
            
            EasyAudio[] audios = Resources.LoadAll<EasyAudio>(ResourcePath);
            foreach (EasyAudio eAudio in audios){
                Audios.Add(eAudio.audioName, eAudio);
            }
        }

        public EasyAudio GetAudio(string audioName){
            return Audios[audioName];
        }
        
        public void PlayAudio(string audioName){
            EasyAudio easyAudio = GetAudio(audioName);
            PlayAudio(easyAudio);
        }
        
        public void PlayAudio(EasyAudio easyAudio){
            audioSource.clip = easyAudio.audioClip;
            audioSource.volume = easyAudio.volume;
            audioSource.pitch = Random.Range(easyAudio.pitchRange.x, easyAudio.pitchRange.y);
            audioSource.PlayOneShot(easyAudio.audioClip);
        }
    }
}