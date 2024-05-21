using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class VisionTouchReceiverLogger : VisionTouchReceiver {

    public override void OnTouch(Touch touch, SpatialPointerState spatialPointerState) {
        Debug.Log("Touch detected");
    }

}