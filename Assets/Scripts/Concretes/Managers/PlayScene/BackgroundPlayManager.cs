

using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Concretes.Controllers.PlayScene;
using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class BackgroundPlayManager : Manager
    {
        public static BackgroundPlayManager Instance { get; private set; }
        [SerializeField] protected List<AudioClip> audienceVoices;

        private SpawnParallaxBackground _spawnParallaxBackground;
        private SpawnAudioAudience _sqawmAudioAudience;
        private AudioSource _hostSource;
        public bool IsMoveBackgroud { get; set; } = false;
        private BoxVocabularyState _boxVocabularyState;


        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnParallaxBackground = GetComponentInChildren<SpawnParallaxBackground>();
            _sqawmAudioAudience = GetComponentInChildren<SpawnAudioAudience>();
            _boxVocabularyState = GetComponentInChildren<PushUpBoxVocabulary>();
            _hostSource = GetComponent<AudioSource>();
            AdjustObjects();
        }

        private void Start()
        {
            StartCoroutine(StartPlayAfferIntro());
        }
        private void Update()
        {
            if (IsMoveBackgroud)
            {
                _spawnParallaxBackground.SpawnObjectState();
              
            }
        }
        public override void AdjustObjects()
        {
            _sqawmAudioAudience.SpawnObjectState();
            audienceVoices = _sqawmAudioAudience.GetListAudios();
        }
      
        public IEnumerator StartPlayAfferIntro()
        {
            AudioPlayManager.Instance.PlaySfx(_hostSource, audienceVoices, EnumAudienceVoice.AudienceCheering);
            yield return GetDelaySecond(1f);
            AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioIntro);
            yield return GetDelayWhile(() => AudioPlayManager.Instance.MainSource.isPlaying);
            yield return GetDelaySecond(0.85f);
            CountdownManager.Instance.AdjustObjects();
            yield return GetDelaySecond(3.5f);
            AnimationReferee.Instance.ChangeAnimationGo();
            VocabularyManager.Instance.AdjustObjects();
            yield return GetDelaySecond(1.5f);
            _spawnParallaxBackground.StartAudioBackground();
            IsMoveBackgroud = true;
            _boxVocabularyState.PerformState();
            yield return StartCoroutine(CarPlayManager.Instance.MoveCarsOutOfScreen());
            yield return GetDelaySecond(1f);
            HandClickManager.Instance.AdjustObjects();
            yield return GetDelayWhile(() => AudioPlayManager.Instance.MainSource.isPlaying);
            CarPlayManager.Instance.OnSwichClickLand(true);
           
        }

    }
}
