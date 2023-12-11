
using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class FadeInVocabulary : VocabularyState
    {
        private SpriteRenderer _spriteRenderer;
        private readonly float _blinkSpeed = 0.8f;
        private readonly float wait0_35 = 0.35f;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public override IEnumerator Sequence()
        {
            yield return wait0_35.Wait();
            while (true)
            {
                float targetAlpha = (_spriteRenderer.color.a == 1.0f) ? 0.4f : 1.0f;

                float t = 0f;
                while (t < _blinkSpeed)
                {
                    t += Time.deltaTime * _blinkSpeed;
                    Color lerpedColor = new(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, Mathf.Lerp(_spriteRenderer.color.a, targetAlpha, t));
                    _spriteRenderer.color = lerpedColor;
                    yield return null;
                }

                yield return null;
            }
        }

        public override IEnumerator PlayEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}
