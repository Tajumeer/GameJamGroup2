using UnityEngine;

namespace Sounds
{
    [CreateAssetMenu(fileName = "Empty audio asset", menuName = "Data/AudioClip")]
    public class AudioClipAsset : ScriptableObject
    {
        public ClipTextCombination Clip { get => m_clip; }

        [SerializeField]
        private ClipTextCombination m_clip;
    }
}
