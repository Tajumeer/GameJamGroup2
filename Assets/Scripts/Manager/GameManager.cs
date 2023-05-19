using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] private GameObject m_shipObject;

        public bool IsShowingShipInside;
        
        
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            
        }

        void Update()
        {
            if (SceneManager.GetActiveScene().name == "LoadingCargeShipInside") ;
            {
                IsShowingShipInside = true;
            }
            m_shipObject.SetActive(IsShowingShipInside);
        }

        private void OnDestroy()
        {
            if (this == Instance)
                Instance = null;
        }
    }
}