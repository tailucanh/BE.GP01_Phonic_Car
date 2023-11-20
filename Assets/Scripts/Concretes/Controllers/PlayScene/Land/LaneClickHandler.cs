using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LaneClickHandler : ClickableObject
{
  

    private void OnMouseDown()
    {
        if (BackgroundPlayManager.Instance.IsMoveBackgroud)
        {
            IsClickAble = true;
            Click();
        };
  
    }
    public override void Click()
    {
        if (IsClickAble)
        {
            StartCoroutine(CarPlayManager.Instance.ChangeLandCar(transform));
            CarPlayManager.Instance.ChangeSpeed(transform);

            HandClickManager.Instance.HideHand();

        }
      
    }

    public override void PlayEffect()
    {
        throw new System.NotImplementedException();
    }
  
}
