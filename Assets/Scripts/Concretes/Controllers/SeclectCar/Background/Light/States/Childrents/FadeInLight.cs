using Assets.Scripts.Utilities;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class FadeInLight : LightState
    {
        private SpriteRenderer _spriteRenderer;
        private float _blinkSpeed = 0.8f;
        private float wait0_5 = 0.5f;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public override IEnumerator Sequence()
        {
            yield return wait0_5.Wait();
            while (true) 
            {
                float targetAlpha = (_spriteRenderer.color.a == 1.0f) ? 0.3f : 1.0f; 

                float t = 0f;
                while (t < _blinkSpeed)
                {
                    t += Time.deltaTime * _blinkSpeed;
                    Color lerpedColor = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, Mathf.Lerp(_spriteRenderer.color.a, targetAlpha, t));
                    _spriteRenderer.color = lerpedColor;
                    yield return null;
                }

                yield return null;
            }
        }
    }
}
