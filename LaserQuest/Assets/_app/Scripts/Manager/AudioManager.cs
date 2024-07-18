using System;
using UnityEngine;

namespace _app.Scripts.Manager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public AudioClip audio;
        public AudioSource audioSource;
        

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(obj:this);
                
            }
            else
            {
                instance = this;
            }
        }

        public void PlayAudio()
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
}