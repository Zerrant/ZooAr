using UnityEngine;

public class MenuRouting : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _loginScreen;
    [SerializeField] private GameObject _registerScreen;

    private void Start() {
        _startScreen.SetActive(true);
        _loginScreen.SetActive(false);
        _registerScreen.SetActive(false);
    }

    public void OnStartScreenClick() {
        _startScreen.SetActive(false);
        _loginScreen.SetActive(true);
    }

    public void OnRegisterClick() {
        _loginScreen.SetActive(false);
        _registerScreen.SetActive(true);
    }

    public void OnLoginClick() {
        _loginScreen.SetActive(true);
        _registerScreen.SetActive(false);
    }
}
