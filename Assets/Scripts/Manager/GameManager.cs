using System;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        
        
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
        }
        
        void Update()
        {
        }

        private void OnDestroy()
        {
            if (this == Instance)
                Instance = null;
        }
    }
}