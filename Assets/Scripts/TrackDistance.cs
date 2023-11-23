using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

/// <summary>
/// Отслеживание положения камеры пользователя.
/// </summary>
[RequireComponent(typeof(ImageTargetBehaviour), typeof(DefaultObserverEventHandler))]
public class TrackDistance : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _popupText;
    [SerializeField] private Button _closeButton;

    [Header("Animal model components")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _prefabObject;
    [SerializeField] [TextArea(5, 10)] private string _description;

    private GameObject _instantiateObject;
    private Transform _cahcedTransform;
    private Animator _anim;
    private bool _objectActive = false;

    /// <summary>
    /// Показать объекты когда найдена карточка.
    /// </summary>
    public void OnTargetFound() {
        if (_instantiateObject == null) InstantiatePrefab();

        if (!_objectActive) {
            _instantiateObject.SetActive(true);
            _objectActive = true;
        }

        _popup.SetActive(true);
        _popupText.text = _description;

        _closeButton.onClick.AddListener(CloseDescription);

#if DEBUG
        Debug.Log(_instantiateObject.name);
#endif
    }

    /// <summary>
    /// Скрыть объекты, когда карточка пропала из вида камеры.
    /// </summary>
    public void OnTargetLost() {
        if (_instantiateObject == null) return;

        _instantiateObject.SetActive(false);
        _popup.SetActive(false);

        _closeButton.onClick.RemoveListener(CloseDescription);

        _objectActive = false;
    }

    private void Start() {
        _cahcedTransform = GetComponent<Transform>();

        _popup.SetActive(false);
        _popupText.text = string.Empty;
    }

    private void Update() {
        if (!_objectActive) return;

        var distance = Vector3.Distance(
            new(_camera.transform.position.x, 0, _camera.transform.position.x),
            new(_instantiateObject.transform.position.x, 0, _instantiateObject.transform.position.x));

        _anim.SetFloat("Distance", distance);

        var directionToCharacter = (_camera.transform.position - _instantiateObject.transform.position).normalized;

        if (distance > 15) {
            _instantiateObject.transform.rotation = Quaternion.LookRotation(new(directionToCharacter.x, 0, directionToCharacter.z));
            _anim.SetFloat("Run", 15.0f);
            _instantiateObject.transform.Translate(5.0f * Time.deltaTime * Vector3.forward);
        } else {
            _anim.SetFloat("Run", 5.0f);
        }
    }

    /// <summary>
    /// Создать на сцене модель.
    /// </summary>
    private void InstantiatePrefab() {
        if (_prefabObject != null) {
            _instantiateObject = Instantiate(_prefabObject, _cahcedTransform);
            _instantiateObject.SetActive(true);
            _objectActive = true;
            _anim = _instantiateObject.GetComponent<Animator>();
        }
    }

    private void CloseDescription() {
        _popup.SetActive(false);
    }
}

