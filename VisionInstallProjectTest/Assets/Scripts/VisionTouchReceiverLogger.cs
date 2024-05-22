using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/// <summary>
/// Logs to the console when a touch is detected.
/// </summary>
public class VisionTouchReceiverLogger : VisionTouchReceiver {

    public override void OnTouch(Touch touch, SpatialPointerState spatialPointerState) {
        Debug.Log("Touch detected");
    }

}