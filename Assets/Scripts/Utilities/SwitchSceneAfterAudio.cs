using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utilities
{

    [RequireComponent(typeof(AudioSource))]
    public class SwitchSceneAfterAudio : MonoBehaviour
    {


        private AudioSource _audioSource;
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void LoadSceneAfterAudio(int id)
        {
            _audioSource.Play();
            StartCoroutine(DelayLoad(id));
        }

        private IEnumerator DelayLoad(int id)
        {
            yield return new WaitWhile(() => _audioSource.isPlaying);
            SceneManager.LoadScene(id);
        }
    }
}