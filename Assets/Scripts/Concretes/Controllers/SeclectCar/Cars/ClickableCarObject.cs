using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class ClickableCarObject : ClickableObject
    {
        private AudioSource _audioSource;
        private bool hasBeenClicked = false;
        private SkeletonAnimation skeletonAnimation;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();

            if (!TryGetComponent<SkeletonAnimation>(out skeletonAnimation))
            {
                Debug.LogError("SkeletonAnimation component not found!");
                return;
            }
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
                StartCoroutine(BoxSelectCarManager.Instance.OnClickableCar());
                PlayEffect();
                GameHelper.SetString(EnumPlayerPrefs.CarSelected.ToString(),
                    GetAnimationResult(skeletonAnimation.AnimationState.GetCurrent(0).Animation.Name));
            }
        }

        public override void PlayEffect()
        {
            AudioSelectCarManager.Instance.PlaySfx(_audioSource);
        }
        private string GetAnimationResult(string currentAnimationKey)
        {

            if(currentAnimationKey.Equals(GameHelper.GetDescription(EnumSlectCart.PinkCar)))
                return GameHelper.GetDescription(EnumSlectCart.PinkCarSelect);
            if(currentAnimationKey.Equals(GameHelper.GetDescription(EnumSlectCart.OrangeCar)))
                return GameHelper.GetDescription(EnumSlectCart.OrangeCarSelect);
            if(currentAnimationKey.Equals(GameHelper.GetDescription(EnumSlectCart.BlueCar))) 
                return GameHelper.GetDescription(EnumSlectCart.BlueCarSelect);
            return "";
          
        }
    }
}
