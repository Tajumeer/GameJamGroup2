using UnityEngine;

namespace LoadingShipp
{
    public class CargoTetrisManager : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
