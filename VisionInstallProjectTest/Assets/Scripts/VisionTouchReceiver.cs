using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/// <summary>
/// Gets called when a touch event occurs.
/// </summary>
public abstract class VisionTouchReceiver : MonoBehaviour {

    public abstract void OnTouch(Touch touch, SpatialPointerState spatialPointerState);

}