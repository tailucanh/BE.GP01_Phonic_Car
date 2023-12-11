using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ClickableLandObject : ClickableObject
    {
        private void OnMouseDown()
        {
            IsClickAble = true;
            Click();
        }
        public override void Click()
        {
            if (IsClickAble)
            {
                
                CarPlayManager.Instance.ChangeLandCar();
                CarPlayManager.Instance.ChangeSpeedLand(transform);
                HandClickManager.Instance.HideHand();
                IsClickAble = false;
            }
        }

        public override void PlayEffect()
        {
            throw new System.NotImplementedException();
        }

    }
}