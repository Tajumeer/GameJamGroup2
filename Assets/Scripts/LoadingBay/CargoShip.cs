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

        private void OnTriggerEnter2D(Collider2D _other)
        {
            if (!_other.gameObject.CompareTag("Cargo")) return;
            Destroy(_other.gameObject);
            m_cargoLoaded++;
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
                SceneManager.LoadScene("LoadingCargeShipInside");
            }
        }
    }
}