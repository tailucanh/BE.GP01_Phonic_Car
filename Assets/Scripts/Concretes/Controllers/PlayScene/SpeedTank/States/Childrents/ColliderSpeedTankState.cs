using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class ColliderSpeedTankState : SpeedTankState, ICollideHandler
    {
        public string StateCollide { get; set; } = EnumStateVocabulary.Start.ToString();

        public float MissedTurn { get; set; }

        public void SetState(EnumStateVocabulary enumState)
        {
            StateCollide = enumState.ToString();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SetState(EnumStateVocabulary.IsCollision);
                PlayEffect();
                StopCoroutine(Sequence());
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        public override IEnumerator Sequence()
        {

            moveableObject = GetComponent<MoveableSpeedTank>();
            targetPosition = new Vector3(GameHelper.GetCameraLeftBound() - 3f, transform.position.y, transform.position.z);
            StartCoroutine(moveableObject.MoveObject(targetPosition, 6f));
            yield return null;
        }
        public override void PlayEffect()
        {
            AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioCollectItem);
        }

    
    }
}