using UnityEngine;

namespace Sounds
{
    [System.Serializable]
    public class ClipTextCombination
    {
        public AudioClip AudioClip => m_audioClip;
        public string Text => m_text;

        [SerializeField]
        private AudioClip m_audioClip = null;
        [SerializeField]
        private string m_text = string.Empty;
    }
}
