using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class CarPlayManager : Manager
    {
        [SerializeField] protected List<GameObject> listsCar;
        [SerializeField] protected List<GameObject> listsLand;

        private SpawnCarPlay _spawnerCarPlay;
        private SpawnLands _sqawmLands;
        public static CarPlayManager Instance { get; private set; }

        private Camera mainCamera;
        float speedChangeLand = 0.25f;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnerCarPlay = GetComponentInChildren<SpawnCarPlay>();
            _sqawmLands = GetComponentInChildren<SpawnLands>();
            AdjustObjects();
            mainCamera = Camera.main;
        }

        public override void AdjustObjects()
        {
            _spawnerCarPlay.SpawnObjectState();
            listsCar = _spawnerCarPlay.GetListsCar();
            _sqawmLands.SpawnObjectState();
            listsLand = _sqawmLands.GetListLand();
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


        public float ChangeSpeed(Transform transformLand)
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

        public IEnumerator ChangeLandCar(Transform transformLand)
        {
            List<GameObject> landsBot = new List<GameObject>(listsLand);
            landsBot.Remove(transformLand.gameObject);
            StopAllCoroutines();
            if (transform != null)
            {
                foreach (var car in listsCar)
                {
                    IPlayerInput playerInput = car.GetComponent<IPlayerInput>();
                    if (playerInput.UseBot)
                    {
                       
                        MoveableObject moveablePlayCar = car.GetComponent<MoveableCarPlay>();
                        Vector3 playerPosition = car.transform.position;
                        Vector3 bottomY = transformLand.GetComponent<BoxCollider2D>().bounds.min;
                        Vector3 toChangeLand = new Vector3(playerPosition.x, bottomY.y, playerPosition.z);
                        StartCoroutine(moveablePlayCar.MoveObject(toChangeLand, speedChangeLand));
                    }
                    if (!playerInput.UseBot)
                    {
                        MoveableObject moveableCarBot = car.GetComponent<MoveableCarBot>();
                        GameObject randomLand = landsBot[Random.Range(0, landsBot.Count)];
                        landsBot.Remove(randomLand);
                        Vector3 botPosition = car.transform.position;
                        Vector3 bottomY = randomLand.GetComponent<BoxCollider2D>().bounds.min;
                        Vector3 toChangeLand = new Vector3(botPosition.x, bottomY.y, botPosition.z);

                        StartCoroutine(moveableCarBot.MoveObject(toChangeLand, speedChangeLand));
                    }
                }
            }

            yield return null;

        }

        public IEnumerator MoveCarsOutOfScreen()
        {
            List<float> moveDurationBot = new List<float> { 10f, 12.35f };
          
            foreach (var car in listsCar)
            {
                IPlayerInput playerInput = car.GetComponent<IPlayerInput>();
                MoveableObject moveableCarObject = car.GetComponent<MoveableCarBot>();
                if (!playerInput.UseBot)
                {
                  
                    Vector3 originalPosition = car.transform.position;
                    float cameraWidth = Camera.main.orthographicSize * 2 * mainCamera.aspect;

                    float moveSpeed = moveDurationBot[Random.Range(0, moveDurationBot.Count)];
                    moveDurationBot.Remove(moveSpeed);
                    float targetX = mainCamera.transform.position.x + cameraWidth / 2;
                    Vector3 targetPosition = new Vector3(targetX + 3f, originalPosition.y, originalPosition.z);
                  
                    StartCoroutine(moveableCarObject.MoveObject(targetPosition, moveSpeed));

                }
            }
            yield return null;
        }

    }

}
