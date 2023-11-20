using Assets.Scripts.Concretes.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Concretes.Controllers
{
    public class ScaleText : TextTitleState
    {
        public float scaleDuration = 0.3f;
        private Vector3 defaultScale;

        private void Awake()
        {
            defaultScale = transform.localScale;
        }
        public override IEnumerator Sequence()
        {
            float startTime = Time.time;
            float elapsedTime = 0f;
            _audioSource = GetComponent<AudioSource>();
            AudioSelectCarManager.Instance.PlaySfx(_audioSource);
            Vector3 toScale = new Vector3(defaultScale.x * 1.2f, defaultScale.y * 1.2f, defaultScale.z);
            while (elapsedTime < scaleDuration)
            {
                transform.localScale = Vector3.Lerp(Vector3.zero, toScale, elapsedTime / scaleDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = toScale; 

            yield return new WaitForSeconds(0.05f);

            startTime = Time.time;
            elapsedTime = 0f;

            while (elapsedTime < scaleDuration)
            {
                transform.localScale = Vector3.Lerp(toScale, defaultScale, elapsedTime / scaleDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = defaultScale;
        }
    }
}
