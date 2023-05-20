using UnityEngine;

namespace StartSequence
{
    [CreateAssetMenu(fileName = "New screen fade", menuName = "Data/ScreenFade")]
    public class ScreenFadeAsset : ScriptableObject
    {
        public Color TargetColor => m_targetColor;
        public float FadeDuration => m_fadeDuration;

        [SerializeField]
        private Color m_targetColor = Color.black;
        [SerializeField]
        private float m_fadeDuration = 1.0f;
    }
}