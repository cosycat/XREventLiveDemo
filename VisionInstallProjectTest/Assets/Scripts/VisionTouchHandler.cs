using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/// <summary>
/// Receives touch events and forwards them to the appropriate VisionTouchReceiver(s) on the touched object.
/// </summary>
public class VisionTouchHandler : MonoBehaviour {

    private void Start() {
        EnhancedTouchSupport.Enable();
    }
        
    private void Update() {
        // get the touches
        var touches = Touch.activeTouches;
        
        if (touches.Count <= 0) return;
        
        foreach (var touch in touches) {
            // get details about the touch
            var spatialPointerState = EnhancedSpatialPointerSupport.GetPointerState(touch);
            
            if (spatialPointerState.Kind != SpatialPointerKind.DirectPinch && spatialPointerState.Kind != SpatialPointerKind.IndirectPinch) continue;
            var touchedObject = spatialPointerState.targetObject;
            if (touchedObject == null) return;
            
            var visionTouchReceivers = touchedObject.GetComponents<VisionTouchReceiver>();
            
            foreach (var touchReceiver in visionTouchReceivers) {
                // forward the touch to the VisionTouchReceiver
                touchReceiver.OnTouch(touch, spatialPointerState);
            }
            
        }
    }
    
}