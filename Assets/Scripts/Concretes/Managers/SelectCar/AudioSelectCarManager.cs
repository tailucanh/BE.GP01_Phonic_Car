using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{

    [RequireComponent(typeof(AudioSource))]
    public class AudioSelectCarManager : Manager
    {
        [SerializeField] protected List<AudioClip> AudioChoosedCar;

        IPlayingObjectSfx playingObjectSfx;
        public AudioSource MainSource { get; private set; }

        private SpawnAudioSelectedCar _sqawmAudioSelectedCar;
        public static AudioSelectCarManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
                Instance = this;

            _sqawmAudioSelectedCar = GetComponentInChildren<SpawnAudioSelectedCar>();
            AdjustObjects();
        }
        private void Start()
        {
            MainSource = GetComponent<AudioSource>();
            playingObjectSfx = new PlayingObjectSfx();
        }

        public override void AdjustObjects()
        {
            _sqawmAudioSelectedCar.SpawnObjectState();
            AudioChoosedCar = _sqawmAudioSelectedCar.GetListAudios();
        }

        public void PlaySfx(AudioSource audioSource)
        {
            playingObjectSfx.PlaySfx(audioSource);
        }
        public void PlaySfx(AudioClip audioClip)
        {
            playingObjectSfx.PlaySfx(MainSource, audioClip);
        }

        public void StopSfx(AudioSource audioSource)
        {
            audioSource.Stop();
        }
        public void RandomAudioSelectedCar()
        {
            if (AudioChoosedCar != null && AudioChoosedCar.Count > 0)
            {
                int randomIndex = Random.Range(0, AudioChoosedCar.Count);
                AudioClip randomClip = AudioChoosedCar[randomIndex];
                PlaySfx(randomClip);
            }
            else
            {
                Debug.LogWarning("AudioClips array is null or empty.");
            }
        }

        public IEnumerator LoadSceneAfterAudioPlay(int scene)
        {
            yield return CoroutineHelper.WaitInWhile(() => MainSource.isPlaying);
            yield return wait0_2.Wait();
            SceneLoader.Instance.LoadScene(scene);
        }
         


    }
}
