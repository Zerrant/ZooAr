using UnityEngine;

/// <summary>
/// Осуществляет навигацию по меню приложения.
/// </summary>
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

    /// <summary>
    /// Обработать нажатие на стартовый экран.
    /// </summary>
    public void OnStartScreenClick() {
        _startScreen.SetActive(false);
        _loginScreen.SetActive(true);
    }

    /// <summary>
    /// Обработать нажатие на строку с предллжением регистрации.
    /// </summary>
    public void OnRegisterClick() {
        _loginScreen.SetActive(false);
        _registerScreen.SetActive(true);
    }

    /// <summary>
    /// Обработать нажатие на строку с предложением войти в аккаунт.
    /// </summary>
    public void OnLoginClick() {
        _loginScreen.SetActive(true);
        _registerScreen.SetActive(false);
    }
}
