using UnityEngine;

namespace Metis.ItemMenu
{
    public class WearableMenuDisplayHandler : MonoBehaviour
    {
        private bool _menuIsShown;

        [SerializeField] private GameObject _menu;
        [SerializeField] private ThirdPersonCamera _cameraController;
        [SerializeField] private CameraSpinner _cameraSpinner;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _menuIsShown = !_menuIsShown;
                // Lock camera
                _cameraController.enabled = !_menuIsShown;

                // Spin camera
                _cameraSpinner.enabled = _menuIsShown;

                // Show menu
                _menu.SetActive(_menuIsShown);
            }
        }
    }
}