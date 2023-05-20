using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadingBay
{
    public class CargoShip : MonoBehaviour
    {
        [SerializeField] private int m_cargoNeeded;
        private int m_cargoLoaded;
        private bool m_isFullyLoaded;
        private bool m_isLoaded;

        private void OnTriggerEnter2D(Collider2D _other)
        {
            if (!_other.gameObject.CompareTag("Cargo")) return;
            Destroy(_other.gameObject);
            m_cargoLoaded++;
        }

        private void Awake()
        {
            m_isLoaded = false;
        }

        private void Update()
        {
            if (m_cargoLoaded == m_cargoNeeded)
            {
                m_isFullyLoaded = true;
            }

            if (m_isFullyLoaded)
            {
                Debug.Log("Puzzle solved!");
                Physics2D.gravity = Vector2.down;
                NextScene();
            }
        }

        private void NextScene()
        {
            if (m_isLoaded) return;
            SceneManager.LoadScene("LoadingCargeShipInside", LoadSceneMode.Single);
            m_isLoaded = true;
        }
    }
}