using System;
using System.Collections.Generic;
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
        [SerializeField] private float m_lerpSpeed;
        [SerializeField] private float m_gravityMultiplier;
        
        private Quaternion m_hangarRotation;
        
        private void Awake()
        {
            m_hangarRotation = m_hangar.transform.rotation;
        }

        private void Start()
        {
            m_rotationSlider.onValueChanged.AddListener(delegate { HangarRotationChange(); });
            m_gravitySlider.onValueChanged.AddListener(delegate { CargoGravityChange(); });
        }


        private void CargoGravityChange()
        {

            Physics2D.gravity = new Vector2(0, m_gravitySlider.value * m_gravityMultiplier);

        }

        private void HangarRotationChange()
        {
            Quaternion targetRotation = Quaternion.Euler(m_hangarRotation.x, m_hangarRotation.y, m_rotationSlider.value);
            m_hangar.transform.rotation = Quaternion.Lerp(m_hangar.transform.rotation, targetRotation, Time.deltaTime * m_lerpSpeed);
        }
    }
}