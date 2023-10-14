using TMPro;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(ImageTargetBehaviour), typeof(DefaultObserverEventHandler))]
public class TrackDistance : MonoBehaviour
{
    [SerializeField] private TMP_Text _worldText;
    [SerializeField] private Canvas _worldCanvas;
    [SerializeField] private TMP_Text _screenText;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _prefabObject;

    private GameObject _instantiateObject;
    private Transform _cahcedTransform;
    private bool _objectActive = false;

    public void OnTargetFound() {
        if (_instantiateObject == null) InstantiatePrefab();

        _worldCanvas.gameObject.SetActive(true);
        _screenText.gameObject.SetActive(true);
        _screenText.text = "This is T-Rex!\nWroar!!!";
    }

    public void OnTargetLost() {
        if (_instantiateObject == null) return;

        _instantiateObject.SetActive(false);
        _worldCanvas.gameObject.SetActive(false);
        _screenText.gameObject.SetActive(false);
        _objectActive = false;
    }

    private void Start() {
        _cahcedTransform = GetComponent<Transform>();
        _worldCanvas.transform.SetParent(_cahcedTransform);
        _worldCanvas.gameObject.SetActive(false);

        _screenText.gameObject.SetActive(false);
        _screenText.text = string.Empty;
    }

    private void Update() {
        if (_objectActive) {
            var distance = Vector3.Distance(_camera.transform.position, _instantiateObject.transform.position);
            _worldText.text = $"Distance between camera and model is {distance}";
        }
    }

    private void InstantiatePrefab() {
        if (_prefabObject != null) {
            _instantiateObject = Instantiate(_prefabObject, _cahcedTransform);
            _instantiateObject.SetActive(true);
            _objectActive = true;
        }
    }
}
