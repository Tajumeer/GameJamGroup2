using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadingShipp
{
    public class LoadingCheck : MonoBehaviour
    {
        [SerializeField] private int m_cargoAmount;
        private int m_cargoLoaded;

        private void OnTriggerEnter2D(Collider2D _other)
        {
            if (_other.gameObject.CompareTag("Cargo"))
            {
                m_cargoLoaded++;
            }
        }

        private void OnTriggerExit2D(Collider2D _other)
        {
            if (_other.gameObject.CompareTag("Cargo"))
            {
                m_cargoLoaded--;
            }
        }

        private void Update()
        {
            Debug.Log(m_cargoLoaded);
            if (m_cargoLoaded != m_cargoAmount) return;
            GameManager.Instance.IsShowingShipInside = false;
            SceneManager.LoadScene("SpaceshipStartSequence");
        }
    }
}