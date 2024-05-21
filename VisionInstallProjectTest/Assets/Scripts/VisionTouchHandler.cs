using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class VisionTouchHandler : MonoBehaviour {

    private void Start() {
        EnhancedTouchSupport.Enable();
    }
        
    private void Update() {
        var touches = Touch.activeTouches;
        
        if (touches.Count <= 0) return;
        
        foreach (var touch in touches) {
            var spatialPointerState = EnhancedSpatialPointerSupport.GetPointerState(touch);
            var touchedObject = spatialPointerState.targetObject;
            
            if (touchedObject == null)
                return;

            var visionTouchReceivers = touchedObject.GetComponents<VisionTouchReceiver>();
            foreach (var touchReceiver in visionTouchReceivers) {
                touchReceiver.OnTouch(touch, spatialPointerState);
            }
            
        }
    }
    
}