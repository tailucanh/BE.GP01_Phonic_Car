using Assets.Scripts.Abtractions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utilities
{
    [RequireComponent(typeof(AudioSource))]
    public class LoadSceneAfterAudio : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        private IEnumerator LoadSceneByDelay(int scene)
        {
            yield return new WaitWhile(() => _audioSource.isPlaying);
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(scene);
        }

    }
}
