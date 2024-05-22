using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class SceneButton : VisionTouchReceiver {
    
    [SerializeField] private SceneButtonType sceneButtonType;
    
    public override void OnTouch(Touch touch, SpatialPointerState spatialPointerState) {
        if (spatialPointerState.Kind != SpatialPointerKind.DirectPinch && spatialPointerState.Kind != SpatialPointerKind.IndirectPinch)
            return;
        
        switch (touch.phase) {
            case TouchPhase.Began:
                // this animates the button press quickly
                transform.localScale *= 0.9f;
                break;
            case TouchPhase.Ended:
                transform.localScale /= 0.9f;
                
                switch (sceneButtonType) {
                    case SceneButtonType.NextScene:
                        LoadNextScene();
                        break;
                    case SceneButtonType.PreviousScene:
                        LoadPreviousScene();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                break;
        }
    }
    
    private void LoadNextScene() {
        var currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentSceneIndex + 1);
    }
    
    private void LoadPreviousScene() {
        var currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentSceneIndex - 1);
    }
    
    private void LoadScene(int sceneIndex) {
        if (sceneIndex < 0 || sceneIndex >= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            return;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
    
    private enum SceneButtonType {
        NextScene,
        PreviousScene,
    }
    
}