using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Concretes.Managers
{
    public class BoxSelectCarManager :  Manager
    {
        [SerializeField] protected List<GameObject> listsBoxCar;
        private SpawnBoxSelectCar _sqawmBoxSelectCar;

        private readonly float _moveDuration = 0.7f;
        private readonly float _scaleDuration = 0.7f;
        private readonly float _moveDownDuration = 0.35f;
        private readonly float _yOffset = -8f;
        private readonly float _xOffset = 0f;
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

     

        public IEnumerator OnClickableCar()
        {
            TitleSelectCarManager.Instance.FadeOutText();
            LightSelectedCarManager.Instance.AdjustObjects();
            AudioSelectCarManager.Instance.RandomAudioSelectedCar();
            StartCoroutine(AudioSelectCarManager.Instance.LoadSceneAfterAudioPlay(2));
            foreach (var boxCar in listsBoxCar)
            {
                ClickableObject clickableCarObject = boxCar.GetComponentInChildren<ClickableCarObject>();
                MoveableObject moveableCarObject = boxCar.GetComponent<MoveableCarSelect>();

                if (clickableCarObject.IsClickAble)
                {
                    Vector3 originalPosition = boxCar.transform.position;
                    Vector3 originalScale = boxCar.transform.localScale;
          
                    Vector3 toCenter = new(_xOffset, originalPosition.y + 2f, originalPosition.z);
                    Vector3 toScale = new(originalScale.x * 1.5f, originalScale.y * 1.5f, originalScale.z);

                    StartCoroutine(moveableCarObject.MoveObject(toCenter, _moveDuration));
                    StartCoroutine(moveableCarObject.ScaleObject(toScale, _scaleDuration));

                    foreach (var otherBoxCar in listsBoxCar)
                    {
                        if (otherBoxCar != boxCar)
                        {
                            MoveableObject moveableOtherCarObject = otherBoxCar.GetComponent<MoveableCarSelect>();
                            Vector3 originalOtherPosition = otherBoxCar.transform.position;
                            Vector3 toOtherPosition = new(originalOtherPosition.x, originalOtherPosition.y + _yOffset, originalOtherPosition.z);

                            StartCoroutine(moveableOtherCarObject.MoveObject(toOtherPosition, _moveDownDuration));

                        }
                    }


                }
            }
            yield return null;
        }
       
    }
}
