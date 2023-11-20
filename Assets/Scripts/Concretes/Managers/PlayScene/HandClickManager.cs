using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class HandClickManager : Manager
    { 
        private SpawnHand _spawnHand;
        public static HandClickManager Instance { get; private set; }
        private GameObject handObj;
        private bool handHidden = false;
        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnHand = GetComponentInChildren<SpawnHand>();
        }
    
        public override void AdjustObjects()
        {
            _spawnHand.SpawnObjectState();
            handObj = _spawnHand.gameObject;
        
            float centerY = CarPlayManager.Instance.GetRandomLandClick().position.y - CarPlayManager.Instance.GetRandomLandClick().localScale.y / 2;
            handObj.transform.position = new Vector3(handObj.transform.position.x, centerY, handObj.transform.position.z);
            AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioGuidingStart);
        }

        public void HideHand()
        {
            if (!handHidden)
            {
                AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioNiceDriving);
                handHidden = true;
            }
            _spawnHand.DesSpawnObjectState();
         
        }
    }
}
