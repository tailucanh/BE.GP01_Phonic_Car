using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class HandClickManager : Manager
    { 
        [SerializeField] protected GameObject handObj;
        public static HandClickManager Instance { get; private set; }

        private bool handHidden = false;
        private SpawnHand _spawnHand;
        private Transform tranformLand;
        private bool hasSpawned = false;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnHand = GetComponentInChildren<SpawnHand>();
            tranformLand = CarPlayManager.Instance.GetRandomLandClick();
        }
    
        public override void AdjustObjects()
        {
            _spawnHand.SpawnObjectState();
            handObj = _spawnHand.gameObject;

            if (!IsObjectDestroyed(handObj)){
                Vector3 centerY = tranformLand.GetComponent<BoxCollider2D>().bounds.center;
                handObj.transform.position = new(handObj.transform.position.x, centerY.y, handObj.transform.position.z);
                AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioGuidingStart);
            }else {
                Debug.Log("HandObj is NULL");
            }
          
        }

        public void HandClickCollectItem(Transform transformItem)
        {
            if (!hasSpawned)
            {
                _spawnHand.SpawnObjectState();
                handObj = _spawnHand.gameObject;

                if (!IsObjectDestroyed(handObj))
                {
                    Vector3 centerY = transformItem.GetComponent<BoxCollider2D>().bounds.center;
                    handObj.transform.position = new(handObj.transform.position.x, centerY.y, handObj.transform.position.z);
                }
                else
                {
                    Debug.Log("HandObj is NULL");
                }
                hasSpawned = true;
            }
          
        }



        public IEnumerator SpwanVocabluaryFirst()
        {
            yield return CoroutineHelper.WaitInWhile(() => IsObjectDestroyed(handObj));
            yield return wait1.Wait();
            VocabularyManager.Instance.SpwanItemVocabulary();
        }


        public void HideHand()
        {
            _spawnHand.DesSpawnObjectState();
            if (!handHidden)
            {
                StartCoroutine(SpwanVocabluaryFirst());
                AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioNiceDriving);
                handHidden = true;
            }
        }

        protected bool IsObjectDestroyed(GameObject obj)
        {
            return obj == null || !obj;
        }
    }
}
