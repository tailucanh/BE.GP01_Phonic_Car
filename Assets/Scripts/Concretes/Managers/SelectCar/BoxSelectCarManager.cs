using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Concretes.Controllers.PlayScene;

namespace Assets.Scripts.Concretes.Managers
{
    public class BoxSelectCarManager :  Manager
    {
        [SerializeField] protected List<GameObject> listsBoxCar;
        private SpawnBoxSelectCar _sqawmBoxSelectCar;

        private float _moveDuration = 0.7f;
        private float _scaleDuration = 0.7f;
        private float _moveDownDuration = 0.35f;
        private float _yOffset = -8f;
        private float _xOffset = 0f;
        private float fadeDuration = 0.5f;
        public static BoxSelectCarManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _sqawmBoxSelectCar = GetComponentInChildren<SpawnBoxSelectCar>();
         
            AdjustObjects();
        }

       
        public override void AdjustObjects()
        {
            _sqawmBoxSelectCar.SpawnObjectState();
            listsBoxCar = _sqawmBoxSelectCar.GetListBoxsCar();
        }
    

        public IEnumerator MoveAndScaleObjectsRoutine()
        {
            foreach (var boxCar in listsBoxCar)
            {
                ClickableObject clickableCarObject = boxCar.GetComponentInChildren<ClickableCarObject>();
                MoveableObject moveableCarObject = boxCar.GetComponent<MoveableCarObject>();

                if (clickableCarObject.IsClickAble)
                {
                    Vector3 originalPosition = boxCar.transform.position;
                    Vector3 originalScale = boxCar.transform.localScale;
          
                    Vector3 toCenter = new Vector3(_xOffset, originalPosition.y + 2f, originalPosition.z);
                    Vector3 toScale = new Vector3(originalScale.x * 1.5f, originalScale.y * 1.5f, originalScale.z);

                    StartCoroutine(moveableCarObject.MoveObject(toCenter, _moveDuration));
                    StartCoroutine(moveableCarObject.ScaleObject(toScale, _scaleDuration));

                    foreach (var otherBoxCar in listsBoxCar)
                    {
                        if (otherBoxCar != boxCar)
                        {
                            MoveableObject moveableOtherCarObject = otherBoxCar.GetComponent<MoveableCarObject>();
                            Vector3 originalOtherPosition = otherBoxCar.transform.position;
                            Vector3 toOtherPosition = new Vector3(originalOtherPosition.x, originalOtherPosition.y + _yOffset, originalOtherPosition.z);

                            StartCoroutine(moveableOtherCarObject.MoveObject(toOtherPosition, _moveDownDuration));

                        }
                    }


                }
            }
            yield return null;
        }


        public IEnumerator FadeAndLoadScene(int scene)
        {
            CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();
            float timePassed = 0f;

            while (timePassed < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, timePassed / fadeDuration);
                timePassed += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = 0f;

            SceneManager.LoadScene(scene);

            Destroy(canvasGroup);
        }
    }
}
