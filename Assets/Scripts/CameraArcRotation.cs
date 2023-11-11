using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(Camera))]
public class CameraArcRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1.0f;

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

        // StartCoroutine(InstantiateObject());
    }

    // Нахождение угла при помощи радиуса и длины дуги :) Геометрию знать надо
    private void OnFingerMove(Finger finger) {
        var l = (finger.currentTouch.screenPosition - _previousTouch).x;
        if (l == 0) return;

        var angle = l * 360 / (6.283184f * _radius);
        _cahcedTransform.RotateAround(Vector3.zero, Vector3.up, angle * _rotationSpeed * Time.deltaTime);

        _previousTouch = finger.currentTouch.screenPosition;
    }

    private void OnFingerDown(Finger finger) => _previousTouch = finger.currentTouch.screenPosition;

    private IEnumerator InstantiateObject() {
        string url = "http://192.168.3.9:5012/models/test";   
        var request = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(url, 0);

        yield return request.SendWebRequest();

        AssetBundle bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);
        GameObject cube = bundle.LoadAsset<GameObject>("mosasaurus_final");
        Instantiate(cube);
    }
}