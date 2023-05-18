using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Subtitles : MonoBehaviour
    {
        public static Subtitles Instance { get; private set; }

        [SerializeField]
        private float m_fadeOutDelay = 5.0f;

        private TextMeshProUGUI m_textField = null;
        private Coroutine m_fadeOutTimer = null;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            m_textField = GetComponent<TextMeshProUGUI>();

            this.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        public void DisplayText(string _text)
        {
            m_textField.text = _text;
            this.gameObject.SetActive(true);

            if (m_fadeOutTimer != null)
            {
                StopCoroutine(m_fadeOutTimer);
            }
            m_fadeOutTimer = StartCoroutine(FadeOutTimer());
        }

        private IEnumerator FadeOutTimer()
        {
            yield return new WaitForSeconds(m_fadeOutDelay);

            this.gameObject.SetActive(false);
        }
    }
}
