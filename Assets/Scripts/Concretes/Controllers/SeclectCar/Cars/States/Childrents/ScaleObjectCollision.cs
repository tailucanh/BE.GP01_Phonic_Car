using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class ScaleObjectCollision : SelectCarState
    {
        private bool isScaling = false;
        private Vector3 originalScale;

        private void Awake()
        {
            moveDuration = 0.3f;
            originalScale = transform.localScale;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Equals("Pedestal") && !isScaling)
            {
                StartCoroutine(Sequence());
            }
        }
        public override IEnumerator Sequence()
        {
            isScaling = true;
            float startTime = Time.time;
            float elapsedTime = 0f;
            Vector3 toScale = new Vector3(originalScale.x * 1.1f, originalScale.y * 1.1f, originalScale.z);
            while (elapsedTime < moveDuration)
            {
                transform.localScale = Vector3.Lerp(originalScale, toScale, elapsedTime / moveDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = originalScale;

            isScaling = false;
        }
    }
}
