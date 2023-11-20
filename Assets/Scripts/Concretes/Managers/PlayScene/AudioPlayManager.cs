using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayManager : Manager
    {

        [SerializeField] protected List<AudioClip> speechesAudio;

        IPlayingObjectSfx playingObjectSfx;
        public AudioSource MainSource { get; private set; }

        public static AudioPlayManager Instance { get; private set; }

        private SpawnAudioSpeech _sqawmAudioSpeech;
        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _sqawmAudioSpeech = GetComponentInChildren<SpawnAudioSpeech>();
            AdjustObjects();
        }
        public override void AdjustObjects()
        {
            MainSource = GetComponent<AudioSource>();
            playingObjectSfx = new PlayingObjectSfx();
            _sqawmAudioSpeech.SpawnObjectState();
            speechesAudio = _sqawmAudioSpeech.GetListAudios();
        }
        public void PlaySfx(AudioSource audioSource)
        {
            playingObjectSfx.PlaySfx(audioSource);
        }
        public void PlaySfx(AudioClip audioClip)
        {
            playingObjectSfx.PlaySfx(MainSource, audioClip);
        }
        public void PlaySfx(AudioSource hostSource,List<AudioClip> audioClips, EnumAudienceVoice clipEnum)
        {
            string description =EnumHelper.GetDescription(clipEnum);
            foreach (var audioClip in audioClips)
            {
                if (audioClip.name == description)
                {
                    playingObjectSfx.PlaySfx(hostSource, audioClip);
                    break;
                }
            }
        
        }

        public void PlaySfx(EnumSpeechAudio clipEnum)
        {
            string description = EnumHelper.GetDescription(clipEnum);
            foreach (var audioClip in speechesAudio)
            {
                if (audioClip.name == description)
                {
                    playingObjectSfx.PlaySfx(MainSource, audioClip);
                    break;
                }
            }

        }

        public void StopSfx(AudioSource audioSource)
        {
            audioSource.Stop();
        }


    }
}
