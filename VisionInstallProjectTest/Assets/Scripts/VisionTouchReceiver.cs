using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public abstract class VisionTouchReceiver : MonoBehaviour {

    public abstract void OnTouch(Touch touch, SpatialPointerState spatialPointerState);

}