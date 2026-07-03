using System;
using DG.Tweening;
using UnityEngine;

namespace frontend
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance { get; private set; }
        
        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _sfx;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        private void Start()
        {
            _music.loop = true;
        }

        public void PlaySfx(AudioClip clip, float volume = 1f)
        {
            _sfx.PlayOneShot(clip, volume);    
        }

        public void PlayMusic(AudioClip clip, float volume = 0.1f)
        {
            _music.clip = clip;
            _music.Play();
        }
    }   
}