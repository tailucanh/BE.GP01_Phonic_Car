using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnParallaxBackground : SpawnObjectAddressables, ISpeedable
    {
        [SerializeField] protected GameObject back1;
        [SerializeField] protected GameObject back2;
        private AudioSource audioSource;
        public float Speed { get; set; }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void SetSpeed(float value)
        {
            Speed = value;
        } 

        public override void SpawnObjectState()
        {
            MoveBackground(back1, Speed);
            MoveBackground(back2, Speed);
        }

        protected void MoveBackground(GameObject background, float speed)
        {
            Vector3 currentPosition = background.transform.position;
            Vector3 newPosition = new(currentPosition.x - speed * Time.deltaTime, currentPosition.y, currentPosition.z);

            background.transform.position = newPosition;

            SpriteRenderer spriteRenderer = background.GetComponent<SpriteRenderer>();
            float backgroundWidth = spriteRenderer.bounds.size.x;

            if (currentPosition.x + backgroundWidth / 2f < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect)
            {
                float offset = backgroundWidth * 1.8f;
                background.transform.position = new Vector3(currentPosition.x + offset, currentPosition.y, currentPosition.z);
            }
        }

        public void StartAudioBackground()
        {
            AudioPlayManager.Instance.PlaySfx(audioSource);
        }
        public void StopAudioBackground()
        {
            AudioPlayManager.Instance.StopSfx(audioSource);
        }

        public override void DesSpawnObjectState()
        {
            throw new System.NotImplementedException();
        }

       
    }
}