using StartSequence.UI;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Subtitles : MonoBehaviour, IInteractionTextDisplay, IHoverTextDisplay
    {
        [SerializeField]
        private float m_fadeOutDelay = 5.0f;

        private TextMeshProUGUI m_textField = null;
        private Coroutine m_fadeOutTimer = null;

        private string m_hoverTextQueue = string.Empty;
        private bool m_isDisplayHoverText = false;

        private void Awake()
        {
            m_textField = GetComponentInChildren<TextMeshProUGUI>();
        }

        private IEnumerator FadeOutTimer()
        {
            yield return new WaitForSeconds(m_fadeOutDelay);

            m_textField.text = string.Empty;

            if (m_hoverTextQueue != string.Empty)
            {
                m_isDisplayHoverText = true;
                UpdateText(m_hoverTextQueue);
                yield break;
            }

            m_textField.gameObject.SetActive(false);
        }

        public void UpdateInteractionText(string _text)
        {
            m_isDisplayHoverText = false;

            UpdateText(_text);
        }

        private void UpdateText(string _text)
        {
            m_textField.text = _text;
            m_textField.gameObject.SetActive(true);

            if (m_fadeOutTimer != null)
            {
                StopCoroutine(m_fadeOutTimer);
            }
            m_fadeOutTimer = StartCoroutine(FadeOutTimer());
        }

        public void RequestUpdateHoverText(string _text)
        {
            if (m_textField.text == string.Empty)
            {
                m_isDisplayHoverText = true;
                UpdateText(_text);
            }
            else
            {
                if (m_isDisplayHoverText)
                {
                    UpdateText(_text);
                }
                else
                {
                    m_hoverTextQueue = _text;
                }
            }
        }

        public void CancelUpdateHoverTextRequest(string _text)
        {
            if (m_hoverTextQueue != _text)
                return;

            m_hoverTextQueue = string.Empty;
        }
    }
}
