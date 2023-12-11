using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class ColliderVocabularyState : VocabularyState, ICollideHandler
    {
        public Transform TargetPoint { get; set; }
        private AudioSource _audioSource;
        private Coroutine currentSequence;

        public string StateCollide { get; set; } = EnumStateVocabulary.Start.ToString();


        private void Start()
        {
            startPosition = transform.position;
        
            _audioSource = GetComponent<AudioSource>();
        }

        public void SetState(EnumStateVocabulary enumState)
        {
            StateCollide = enumState.ToString();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                MissedTurn = 0;
                StopCoroutine(currentSequence); 
                StartCoroutine(OnColliderItem());
                StartCoroutine(PlayEffect());
            }
        }


        protected IEnumerator OnColliderItem()
        {
            moveableObject = GetComponent<MoveableVocabularyItem>();
            moveableObject.IsSmoothness = false;
            Vector3 targetPos = TargetPoint.position;
            yield return StartCoroutine(moveableObject.MoveObject(targetPos, 2.5f));
            transform.SetParent(TargetPoint);
            SetState(EnumStateVocabulary.Start);
        }

        public override IEnumerator Sequence()
        {
            moveableObject = GetComponent<MoveableVocabularyItem>();
            moveableObject.IsSmoothness = true;
            targetPosition = new Vector3(GameHelper.GetCameraLeftBound() - 2f, transform.position.y, transform.position.z);
            currentSequence = StartCoroutine(moveableObject.MoveObject(targetPosition, 6f));
            yield return currentSequence;
            transform.position = startPosition;
            SetState(EnumStateVocabulary.End);
        }


        public override IEnumerator PlayEffect()
        {
            AudioPlayManager.Instance.PlaySfx(EnumSpeechAudio.AudioItemTouch);
            yield return new WaitWhile(() => AudioPlayManager.Instance.MainSource.isPlaying);
            AudioPlayManager.Instance.PlaySfx(_audioSource);
            SetState(EnumStateVocabulary.IsCollision);
         
        }
    }
}
