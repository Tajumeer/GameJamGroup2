using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace LoadingBay
{
    [DisallowMultipleComponent]
    public class PuzzleManager : MonoBehaviour
    {
        #region Variables
        
        [Header("Hangar")]
        [SerializeField] private Slider m_rotationSlider;
        [SerializeField] private GameObject m_hangar;
        [SerializeField] private float m_lerpSpeed;
        private Quaternion m_hangarRotation;
        
        [Header("Gravity Control")]
        [SerializeField] private Slider m_gravitySlider;
        private float m_gravityMultiplierCount;
        private float m_gravityMultiplier;
        
        #endregion
        
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
            Physics2D.gravity = new Vector2(0, m_gravitySlider.value);
        }

        private void HangarRotationChange()
        {
            Quaternion targetRotation = Quaternion.Euler(m_hangarRotation.x, m_hangarRotation.y, m_rotationSlider.value);
            m_hangar.transform.rotation = Quaternion.Lerp(m_hangar.transform.rotation, targetRotation, Time.deltaTime * m_lerpSpeed);
        }
    }
}