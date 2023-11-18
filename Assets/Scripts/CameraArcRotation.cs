using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(Camera))]
public class CameraArcRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.5f;

    private Camera _mainCamera;
    private Transform _cahcedTransform;
    private float _radius = 1.0f;
    private Vector2 _previousTouch;

    void OnEnable() {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
    }

    void Start() {
        Touch.onFingerMove += OnFingerMove;
        Touch.onFingerDown += OnFingerDown;

        _cahcedTransform = GetComponent<Transform>();
        _mainCamera = GetComponent<Camera>();

        _radius = _mainCamera.transform.position.magnitude;
    }

    // Нахождение угла при помощи радиуса и длины дуги :) Геометрию знать надо
    private void OnFingerMove(Finger finger) {
        var l = (finger.currentTouch.screenPosition - _previousTouch).x;
        if (l == 0) return;

        // Производим трансформацию длины отклонения
        // Чем больше разница, тем выше будет скорость, так возрастает квадрат -_-
        l *= Mathf.Abs(l) / 2;

        var angle = l * 360 / (6.283184f * _radius);
        _cahcedTransform.RotateAround(Vector3.zero, Vector3.up, angle * _rotationSpeed * Time.deltaTime);

        _previousTouch = finger.currentTouch.screenPosition;
    }

    private void OnFingerDown(Finger finger) => _previousTouch = finger.currentTouch.screenPosition;
}