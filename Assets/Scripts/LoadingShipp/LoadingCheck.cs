using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadingShipp
{
    public class LoadingCheck : MonoBehaviour
    {
        [SerializeField] private int m_cargoAmount;
        [SerializeField] private GameObject m_loadingShip;
        [SerializeField] private GameObject m_loadingArea;
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
            Physics2D.gravity = Vector2.zero;
            m_loadingShip.SetActive(false);
            m_loadingArea.SetActive(false);
            SceneManager.LoadScene("SpaceshipStartSequence", LoadSceneMode.Additive);
            
        }
        
        
    }
}