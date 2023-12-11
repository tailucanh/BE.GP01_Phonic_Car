using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class GamePlayManager : Manager
    {
        public static GamePlayManager Instance { get; private set; }
        [SerializeField] protected List<AudioClip> audienceVoices;
        public AudioSource HostSource { get; set; }
        public bool IsMoveBackgroud { get; set; } = false;

        private SpawnParallaxBackground _spawnParallaxBackground;
        private SpawnAudioAudience _sqawmAudioAudience;
        private SpawnObjectAddressables _sqawmStartLine;
        private SpawnObjectAddressables _sqawmCountdown;
        private SpawnObjectAddressables _spawnFlags;
        private SpawnObjectAddressables _spawnAudiences;
        private SpawnObjectAddressables _spawnLineEndGame;
        private bool hasSpawned = false;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnParallaxBackground = GetComponentInChildren<SpawnParallaxBackground>();
            _sqawmAudioAudience = GetComponentInChildren<SpawnAudioAudience>();
            _sqawmStartLine = GetComponentInChildren<SpawnStartLine>();
            _sqawmCountdown = GetComponentInChildren<SpawnCountdown>();
            _spawnFlags = GetComponentInChildren<SpawnCongratulationFlags>();
            _spawnAudiences = GetComponentInChildren<SpawnAudiences>();
            _spawnLineEndGame = GetComponentInChildren<SpawnLineEndGame>();
            HostSource = GetComponent<AudioSource>();
            AdjustObjects();
        }

        private void Start()
        {
            _sqawmStartLine.SpawnObjectState();
            StartCoroutine(StartPlayAfferIntro());
            ChangeSpeedBackGroundState(4f);
        }
        private void Update()
        {
            if (IsMoveBackgroud)
            {
                _spawnParallaxBackground.SpawnObjectState();
            }
        }

        public void ChangeSpeedBackGroundState(float value)
        {
            _spawnParallaxBackground.GetComponent<ISpeedable>().SetSpeed(value);
        }

        public override void AdjustObjects()
        {
            _sqawmAudioAudience.SpawnObjectState();
            audienceVoices = _sqawmAudioAudience.GetListAudios();
        }
        
        public void SpawnCongratulationFlags()
        {
            _spawnFlags.SpawnObjectState();
        }


        public IEnumerator StartPlayAfferIntro()
        {
            yield return wait0_5.Wait();
            AudioPlayManager.Instance.PlaySfx(HostSource, audienceVoices, EnumAudienceVoice.AudienceCheering);
            yield return wait0_5.Wait();
            AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioIntro);
            yield return CoroutineHelper.WaitInWhile(() => AudioPlayManager.Instance.MainSource.isPlaying);
            yield return wait0_85.Wait();
            _sqawmCountdown.SpawnObjectState();
            yield return wait3_5.Wait();
            RefereeManager.Instance.ChangeAnimation(EnumAniReferee.Go);
            VocabularyManager.Instance.AdjustObjects();
            _sqawmCountdown.DesSpawnObjectState();
            yield return wait1_5.Wait();
            _spawnParallaxBackground.StartAudioBackground();
            IsMoveBackgroud = true;
            BoxVocabularyManager.Instance.AdjustObjects();
            yield return StartCoroutine(CarPlayManager.Instance.MoveCarsOutOfScreen());
            yield return wait2_5.Wait();
            HandClickManager.Instance.AdjustObjects();
            yield return CoroutineHelper.WaitInWhile(() => AudioPlayManager.Instance.MainSource.isPlaying);
            CarPlayManager.Instance.OnSwichClickLand(true);
            SpeedTankManager.Instance.AdjustObjects();
            _spawnAudiences.SpawnObjectState();
        }
      

        public void ChangeStausAudiences(EnumAniAudience enumAni, float speed)
        {
            AudiencesState audiencesState = _spawnAudiences.GetComponentInChildren<InitializeAudiences>();
            ISpeedable speedable = _spawnAudiences.GetComponentInChildren<InitializeAudiences>();
            speedable.SetSpeed(speed);
            audiencesState.ChangeAnimation(enumAni);
            audiencesState.PerformState();
        }

        public IEnumerator InitializeLineEndGame()
        {
            LineEndGameState lineEndGameState = _spawnLineEndGame.GetComponentInChildren<InitializeLineEndGame>();
            yield return wait6.Wait();
            lineEndGameState.PerformState();
        }

        public void SpawnLineEndGame()
        {
            if (!hasSpawned)
            {
                _spawnLineEndGame.SpawnObjectState();
                hasSpawned = true;
            }
        }

        public void PlaySfxAudience(EnumAudienceVoice enumAudience)
        {
            if (HostSource.isPlaying) return;
            AudioPlayManager.Instance.PlaySfx(HostSource, audienceVoices, enumAudience);
        }
        
    }
}
