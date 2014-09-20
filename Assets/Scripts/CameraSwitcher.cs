using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
    public GameObject riftCamera = null;
    public GameObject mainCamera = null;

    void Start() {
        riftCamera.SetActive(GUIController.isOculusRift);
        mainCamera.SetActive(!GUIController.isOculusRift);
    }

    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            OVRDevice.ResetOrientation();
        }
    }
}
