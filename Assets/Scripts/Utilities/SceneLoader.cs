
using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utilities
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }
        [SerializeField] Animator animator;
        private readonly float wait1 = 1f;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
        }

      
        public void LoadScene(int id)
        {
           StartCoroutine(LoadAnimaton(id));
        }

        protected IEnumerator LoadAnimaton(int id)
        {
            animator.SetTrigger("Start");
            yield return wait1.Wait();
            SceneManager.LoadScene(id);
        }

        
    }
}
