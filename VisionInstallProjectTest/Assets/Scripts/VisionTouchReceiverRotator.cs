using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class VisionTouchReceiverRotator : VisionTouchReceiver {
    
    [SerializeField] private bool3 allowRotation = new(true, true, true);

    private Vector3 _initialTouchRotation;
    private Vector3 _prevTouchRotation;

    public override void OnTouch(Touch touch, SpatialPointerState spatialPointerState) {
        if (spatialPointerState.Kind != SpatialPointerKind.DirectPinch && spatialPointerState.Kind != SpatialPointerKind.IndirectPinch)
            return;
        
        switch (touch.phase) {
            case TouchPhase.Began:
                OnTouchBegan(touch, spatialPointerState);
                break;
            case TouchPhase.Moved:
                OnTouchMoved(touch, spatialPointerState);
                break;
        }
    }

    public void OnTouchBegan(Touch touch, SpatialPointerState spatialPointerState) {
        _initialTouchRotation = spatialPointerState.inputDeviceRotation.eulerAngles;
        _prevTouchRotation = _initialTouchRotation;
    }

    public void OnTouchMoved(Touch touch, SpatialPointerState spatialPointerState) {
        var deviceRotation = spatialPointerState.inputDeviceRotation.eulerAngles;
        // var deltaRotation = deviceRotation - _initialTouchRotation;
        
        var rotationToApply = Vector3.zero;
        if (allowRotation.x) rotationToApply.x = deviceRotation.x - _prevTouchRotation.x;
        if (allowRotation.y) rotationToApply.y = deviceRotation.y - _prevTouchRotation.y;
        if (allowRotation.z) rotationToApply.z = deviceRotation.z - _prevTouchRotation.z;
        
        transform.Rotate(rotationToApply, Space.World);
        _prevTouchRotation = deviceRotation;
    }
}