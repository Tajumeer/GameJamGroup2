using StartSequence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "ScreenFadeAction", menuName = "Data/Actions/ScreenFadeAction")]
    public class ScreenFadeAction : AEventAction
    {
        private bool m_hasFadeFinished = false;

        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            ScreenFadeAsset fadeData = (ScreenFadeAsset)_data;
            Image img = _context.GetComponent<Image>();

            _responder.StartCoroutine(PerformScreenFade(img, fadeData.TargetColor, fadeData.FadeDuration));
        }

        private IEnumerator PerformScreenFade(Image _image, Color _targetColor, float _duration)
        {
            float lerp = 0.0f;
            Color startColor = _image.color;
            while (lerp < 1)
            {
                lerp += Time.deltaTime / _duration;
                _image.color = Color.Lerp(startColor, _targetColor, lerp);

                yield return null;
            }

            _image.color = _targetColor;
            m_hasFadeFinished = true;
        }

        public override bool UpdateAction()
        {
            return m_hasFadeFinished;
        }

        public override void EndAction()
        {
            m_hasFadeFinished = false;
        }

        public override void Reset()
        {
            m_hasFadeFinished = false;
        }
    }
}