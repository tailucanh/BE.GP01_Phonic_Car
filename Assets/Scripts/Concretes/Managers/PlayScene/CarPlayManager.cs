using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class CarPlayManager : Manager
    {
        [SerializeField] protected GameObject carPlayer;
        [SerializeField] protected List<GameObject> listsCarBot;
        [SerializeField] protected List<GameObject> listsLand;
        [SerializeField] protected SpriteRenderer blurBackground;

        private List<GameObject> listsCarAll;
        private SpawnCarPlay _spawnerCarPlay;
        private SpawnLands _sqawmLands;
        public static CarPlayManager Instance { get; private set; }
        private IChangeAnimation changeAnimation;
        float speedChangeLand = 0.25f;
        private bool carAssigned = false;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnerCarPlay = GetComponentInChildren<SpawnCarPlay>();
            _sqawmLands = GetComponentInChildren<SpawnLands>();
            changeAnimation = new ChangeAnimation();
            AdjustObjects();
        }

        public override void AdjustObjects()
        {
            _spawnerCarPlay.SpawnObjectState();
            listsCarAll = _spawnerCarPlay.GetListsCar();
            _sqawmLands.SpawnObjectState();

            listsLand = _sqawmLands.GetListLand();
        }
        private void Update()
        {
            if (!carAssigned && listsCarAll.Count > 0)
            {
                foreach (var car in listsCarAll)
                {
                    IPlayerInput playerInput = car.GetComponent<IPlayerInput>();
                    if (playerInput.UsePlayer)
                    {
                        carPlayer = car;
                    }
                    else
                    {
                        listsCarBot.Add(car);
                    }
                }
                carAssigned = true;
            }
        }

        public void OnChangeCarCollide()
        {
            CarState carPlayState = carPlayer.GetComponent<PlayerCarState>();
            carPlayState.PerformState();
        }

        public IEnumerator OnCarEndGame()
        {
            CarState carPlayState = carPlayer.GetComponent<PlayerCarState>();
            yield return StartCoroutine(carPlayState.SequenceEndGame());
            GamePlayManager.Instance.ChangeSpeedBackGroundState(0f);
            StartCoroutine(MoveCarsBotEndGame());
            GamePlayManager.Instance.SpawnCongratulationFlags();
            Debug.Log("Đã xong");
            GamePlayManager.Instance.PlaySfxAudience(EnumAudienceVoice.AudienceHappy);
            yield return wait4_5.Wait();
            blurBackground.color = new Color(0f,0f,0f,0.5f);
            BoxVocabularyManager.Instance.PushCenterEndGame();
            yield return wait0_5.Wait();
            yield return StartCoroutine(VocabularyManager.Instance.PlaySfxAudioVocabulary());
        }



        public void OnSwichClickLand(bool isSwitch)
        {
            foreach (var land in listsLand)
            {
                land.GetComponent<BoxCollider2D>().enabled = isSwitch;
            }
        }

        public Transform GetRandomLandClick()
        {
            return listsLand[Random.Range(0, listsLand.Count)].transform;
        }

        public float ChangeSpeedLand(Transform transformLand)
        {
            for (int i = 0; i < listsLand.Count; i++)
            {
                if (transformLand.gameObject == listsLand[i])
                {
                  return speedChangeLand = (i % 2 == 0) ? 0.35f : 0.25f;
                }
            }
            return speedChangeLand;
        }

        public void ChangeLandCar()
        {
            VocabularyManager.Instance.ContinueSpwanVocabulary();
            List<GameObject> landsBot = new(listsLand);
            MoveableObject moveablePlayCar = carPlayer.GetComponent<MoveableCarPlay>();
            moveablePlayCar.IsSmoothness = false;
            Vector3 playerPosition = carPlayer.transform.position;
            foreach (var land in listsLand)
            {
                ClickableObject clickableCarObject = land.GetComponentInChildren<ClickableLandObject>();
                if (clickableCarObject.IsClickAble && GamePlayManager.Instance.IsMoveBackgroud)
                {
                    landsBot.Remove(land);
                    Vector3 bottomY = land.GetComponent<BoxCollider2D>().bounds.min;
                    Vector3 toChangeLandPlayer = new(playerPosition.x, bottomY.y, playerPosition.z);
                    StartCoroutine(moveablePlayCar.MoveObject(toChangeLandPlayer, speedChangeLand));
                    foreach (var car in listsCarBot)
                    {
                        GameObject randomLand = landsBot[Random.Range(0, landsBot.Count)];
                        landsBot.Remove(randomLand);
                        Vector3 bottomYBot = randomLand.GetComponent<BoxCollider2D>().bounds.min;
                        Vector3 toChangeLandBot = new(car.transform.position.x, bottomYBot.y, car.transform.position.z);
                        car.transform.position = toChangeLandBot;
                    }
                }

            }
          
        }

        public void MoveCarsBotStateVocabulary(ICollideHandler collideHandler)
        {
            float xRight = GameHelper.GetCameraRightBound();
            float xLeft = GameHelper.GetCameraLeftBound();

            for (int i = 0; i < listsCarBot.Count; i ++)
            {
                MoveableObject botCarState = listsCarBot[i].GetComponent<MoveableCarBot>();
                Vector3 backwardPos = new(xLeft - 3f, listsCarBot[i].transform.position.y, listsCarBot[i].transform.position.z);
                Vector3 forwardPos = new(xRight + 3f, listsCarBot[i].transform.position.y, listsCarBot[i].transform.position.z);
              
                if (collideHandler.StateCollide == EnumStateVocabulary.IsCollision.ToString())
                {
                    if(listsCarBot[i].transform.position.x == xRight + 3f)
                    {
                        StartCoroutine(botCarState.MoveObject(backwardPos, 4f));
                        break;
                    }
                }
                if (collideHandler.StateCollide == EnumStateVocabulary.End.ToString())
                {
                    if (listsCarBot[i].transform.position.x == xLeft - 3f)
                    {
                        StartCoroutine(botCarState.MoveObject(forwardPos, 4f));
                        break;
                    }
                }

            }

        }

        public IEnumerator MoveCarsBotEndGame()
        {
            List<float> moveDurationBot = new() { 3.5f, 5.5f };
            foreach (var car in listsCarBot)
            {
                float moveSpeed = moveDurationBot[Random.Range(0, moveDurationBot.Count)];
                moveDurationBot.Remove(moveSpeed);
                CarState botCarState = car.GetComponent<BotCarState>();
                ISpeedable speedable = car.GetComponentInChildren<BotCarState>();
                speedable.SetSpeed(moveSpeed);
                StartCoroutine(botCarState.SequenceEndGame());
            }
            yield return null;
        }

        public IEnumerator MoveCarsOutOfScreen()
        {
            List<float> moveDurationBot = new() { 3.5f, 5.5f };
            SkeletonAnimation aniCarPlay = carPlayer.GetComponent<SkeletonAnimation>();
         
           /*carPlayer.GetComponent<AnimationWheelBoneState>().PerformState();*/
              changeAnimation.SwitchAnimation(aniCarPlay, GameHelper.ReplaceLastThreeChar(aniCarPlay.AnimationName, "1"), true);
            foreach (var car in listsCarBot)
            {
                /* car.AddComponent<AnimationWheelBoneState>();
                 car.GetComponent<AnimationWheelBoneState>().PerformState();*/
                float moveSpeed = moveDurationBot[Random.Range(0, moveDurationBot.Count)];
                moveDurationBot.Remove(moveSpeed);
                CarState botCarState = car.GetComponent<BotCarState>();
                ISpeedable speedable = car.GetComponentInChildren<BotCarState>();
                speedable.SetSpeed(moveSpeed);
                botCarState.PerformState();
            }
            yield return null;
        }

    }

}
