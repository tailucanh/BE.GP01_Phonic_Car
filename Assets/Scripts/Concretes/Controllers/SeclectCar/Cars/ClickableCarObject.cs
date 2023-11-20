using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class ClickableCarObject : ClickableObject
    {
        private AudioSource _audioSource;
        private IAnimationSelect _animationSelect;
        private bool hasBeenClicked = false;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _animationSelect = GetComponent<IAnimationSelect>();
        }

        private void OnMouseDown()
        {
            if (!hasBeenClicked)
            {
                hasBeenClicked = true;
                IsClickAble = true;
                Click();
            }
        }
        public override void Click()
        {
            if (IsClickAble)
            {
                PlayEffect();
                StartCoroutine(BoxSelectCarManager.Instance.MoveAndScaleObjectsRoutine());
                TitleSelectCarManager.Instance.FadeOutText();
                LightSelectedCarManager.Instance.AdjustObjects();
                AudioSelectCarManager.Instance.RandomAudioSelectedCar();
                PlayerPrefs.SetString(EnumSlectCart.KeySelected.ToString(),GetAnimationResult(_animationSelect.GetAnimation()));
                StartCoroutine(AudioSelectCarManager.Instance.LoadSceneAfterAudioPlay(2));

            }
        }

        public override void PlayEffect()
        {
            AudioSelectCarManager.Instance.PlaySfx(_audioSource);
        }
        private string GetAnimationResult(string currentAnimationKey)
        {

            if(currentAnimationKey.Equals(EnumHelper.GetDescription(EnumSlectCart.PinkCar)))
                return EnumHelper.GetDescription(EnumSlectCart.PinkCarSelect);
            if(currentAnimationKey.Equals(EnumHelper.GetDescription(EnumSlectCart.OrangeCar)))
                return EnumHelper.GetDescription(EnumSlectCart.OrangeCarSelect);
            if(currentAnimationKey.Equals(EnumHelper.GetDescription(EnumSlectCart.BlueCar))) 
                return EnumHelper.GetDescription(EnumSlectCart.BlueCarSelect);
            return "";
          
        }
    }
}
