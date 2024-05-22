using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;

public class HeadFollower : MonoBehaviour {
    
    private Vector3 _positionOffset;
    private HandheldARInputDevice _inputDevice;

    private void Start() {
        _inputDevice = InputSystem.GetDevice<HandheldARInputDevice>();
        if (_inputDevice == null) return;
        var position = _inputDevice.devicePosition.ReadValue();
        _positionOffset = position - transform.position;
    }

    private void Update() {
        if (_inputDevice == null) return;

        var position = _inputDevice.devicePosition.ReadValue();
        var rotation = _inputDevice.deviceRotation.ReadValue();
        transform.position = position - _positionOffset;
        transform.rotation = rotation;
    }
    
}