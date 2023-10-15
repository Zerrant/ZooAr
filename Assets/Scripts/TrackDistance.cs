using TMPro;
using UnityEngine;
using Vuforia;

/// <summary>
/// Отслеживание положения камеры пользователя.
/// </summary>
[RequireComponent(typeof(ImageTargetBehaviour), typeof(DefaultObserverEventHandler))]
public class TrackDistance : MonoBehaviour
{
    [SerializeField] private TMP_Text _worldText;
    [SerializeField] private Canvas _worldCanvas;
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _popupText;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _prefabObject;
    [SerializeField] private Animator _anim;



    private GameObject _instantiateObject;
    private Transform _cahcedTransform;
    private bool _objectActive = false;

    /// <summary>
    /// Показать объекты когда найдена карточка.
    /// </summary>
    public void OnTargetFound()
    {
        if (_instantiateObject == null) InstantiatePrefab();

        _worldCanvas.gameObject.SetActive(true);
        _popup.SetActive(true);
        Debug.Log(_instantiateObject.name);
        switch (_instantiateObject.name)
        {
            case "TRex_main(Clone)":
                _popupText.text = "T-Rex\nЯвляется крупнейшим видом своего семейства, одним из самых больших "
                    + "представителей тероподов и одним из самых крупных наемных хищников за всю историю Земли";
                break;
            case "Pterodactyl(Clone)":
                _popupText.text = "Pterodactyl\nПтеродактили были плотоядными птерозаврами и охотились преимущественно на рыбу и мелких животных";
                break;
            case "parasaurolof(Clone)":
                _popupText.text = "Parasaurolof\nКак и в случае с большинством динозавров, скелеты паразауролофов "
                + "являются неполными. Длина скелета составляет 9,5 метра.";
                break;

        }



    }

    /// <summary>
    /// Скрыть объекты, когда карточка пропала из вида камеры.
    /// </summary>
    public void OnTargetLost()
    {
        if (_instantiateObject == null) return;

        _instantiateObject.SetActive(false);
        _worldCanvas.gameObject.SetActive(false);
        _popup.SetActive(false);

        _objectActive = false;

    }

    private void Start()
    {
        _cahcedTransform = GetComponent<Transform>();
        _worldCanvas.transform.SetParent(_cahcedTransform);
        _worldCanvas.gameObject.SetActive(false);

        _popup.SetActive(false);
        _popupText.text = string.Empty;


    }

    private void Update()
    {
        if (_objectActive)
        {
            var distance = Vector3.Distance(new Vector3(_camera.transform.position.x, 0, _camera.transform.position.x), (new Vector3(_instantiateObject.transform.position.x, 0, _instantiateObject.transform.position.x)));
            _worldText.text = $"Distance between camera and model is {distance}";
            _anim.SetFloat("Distance", distance);

            Vector3 directionToCharacter = (_camera.transform.position - _instantiateObject.transform.position).normalized;


            if (distance > 15)
            {
                _instantiateObject.transform.rotation = Quaternion.LookRotation(new Vector3(directionToCharacter.x, 0, directionToCharacter.z));
                _anim.SetFloat("Run", 15.0f);
                _instantiateObject.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime);
            }
            else
            {

                _anim.SetFloat("Run", 5.0f);
            }





        }







    }

    /// <summary>
    /// Создать на сцене модель.
    /// </summary>
    private void InstantiatePrefab()
    {
        if (_prefabObject != null)
        {
            _instantiateObject = Instantiate(_prefabObject, _cahcedTransform);
            _instantiateObject.SetActive(true);
            _objectActive = true;
            _anim = _instantiateObject.GetComponent<Animator>();
        }
    }
}

