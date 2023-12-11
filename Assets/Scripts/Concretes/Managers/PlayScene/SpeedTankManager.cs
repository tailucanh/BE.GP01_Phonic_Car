using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class SpeedTankManager : Manager
    {
        private SpawnSpeedTank _spawnSpeedTank;
        private ICollideHandler collideHandler;

        public static SpeedTankManager Instance { get; private set; }

        [SerializeField] protected List<GameObject> listsSpeed;


        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnSpeedTank = GetComponentInChildren<SpawnSpeedTank>();
        }
     
        public override void AdjustObjects()
        {
            _spawnSpeedTank.SpawnObjectState();
            listsSpeed = _spawnSpeedTank.GetListSpeedTank();
        }
        
        public IEnumerator StartSpawnSpeedTank()
        {
            foreach (var item in listsSpeed)
            {
                item.GetComponent<SpeedTankState>().PerformState();
                collideHandler = item.GetComponent<ICollideHandler>();
                if (collideHandler.StateCollide == EnumStateVocabulary.IsCollision.ToString())
                {
                    GamePlayManager.Instance.ChangeSpeedBackGroundState(10f);
                    CarPlayManager.Instance.OnSwichClickLand(false);
                    yield return StartCoroutine(CarPlayManager.Instance.OnCarEndGame());
                    collideHandler.SetState(EnumStateVocabulary.End);             
                }

            }
        }
      
    }
}
