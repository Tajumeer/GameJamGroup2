using System;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingBay
{
    [DisallowMultipleComponent]
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] private Slider m_gravitySlider;
        [SerializeField] private Slider m_rotationSlider;
        [SerializeField] private GameObject m_hangar;

        private void Awake()
        {
            
        }

        private void Start()
        {
            m_rotationSlider.onValueChanged.AddListener(delegate { RotationChange(); });
        }

        private void RotationChange()
        {

            m_rotationSlider.value = m_hangar.transform.rotation.z;

        }
    }
}
