using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes
{
    public class PushUpCar : MonoBehaviour
    {
        public float moveDuration = 0.65f;
        public Vector3 targetPosition;

        private Vector3 startPosition;
        private float elapsedTime = 0f;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
            targetPosition = new Vector3(transform.position.x, -3.8f, 0f);
        }

        private void Start()
        {
            StartCoroutine(MoveObjectToTarget());
        }


        protected IEnumerator MoveObjectToTarget()
        {

            while (elapsedTime < moveDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / moveDuration);
                Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);
                rb.MovePosition(newPosition);
                yield return null;
            }

        }

    }
}