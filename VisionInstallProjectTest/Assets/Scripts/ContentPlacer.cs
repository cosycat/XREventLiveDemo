using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PolySpatial;
using UnityEngine;

/// <summary>
/// Places the content in front of the user if unbounded, or at (0/0/0) if bounded.
/// </summary>
public class ContentPlacer : MonoBehaviour {

    private readonly Vector3 _offset = new(0, 1, 1);
    
    private void Start() {
        var volumeCamera = FindObjectOfType<VolumeCamera>();
        if (volumeCamera == null) return;
        var mode = volumeCamera.WindowConfiguration.Mode;
        switch (mode) {
            case VolumeCamera.PolySpatialVolumeCameraMode.Bounded:
                transform.position = Vector3.zero;
                break;
            case VolumeCamera.PolySpatialVolumeCameraMode.Unbounded:
                transform.position = _offset;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}