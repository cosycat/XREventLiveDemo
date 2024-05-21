using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;

public class VisionTouchReceiverMovable : VisionTouchReceiver {
    
    public override void OnTouch(Touch touch, SpatialPointerState spatialPointerState) {
        if (spatialPointerState.Kind != SpatialPointerKind.DirectPinch && spatialPointerState.Kind != SpatialPointerKind.IndirectPinch)
            return;
        if (touch.phase != TouchPhase.Moved)
            return;
        
        transform.position += spatialPointerState.deltaInteractionPosition;
    }
    
}