using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;

/// <summary>
/// Moves the object when pinched.
/// </summary>
public class VisionTouchReceiverMovable : VisionTouchReceiver {
    
    public override void OnTouch(Touch touch, SpatialPointerState spatialPointerState) {
        if (touch.phase != TouchPhase.Moved) return;

        transform.position += spatialPointerState.deltaInteractionPosition;
    }
    
}