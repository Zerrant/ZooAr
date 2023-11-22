using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Осуществление входа в учётную запись пользователя.
/// </summary>
public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _popupText;
    [SerializeField] private Button _popupOkButton;

    /// <summary>
    /// Осуществить вход в учётную запись при нажатии на кнопку войти.
    /// </summary>
    public void OnLoginClicked() {
        StartCoroutine(HttpService.Login(
            new LoginContract { Login = _login.text, Password = _password.text },
            () => {
                if (HttpService.JwtToken != null) {
                    SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
                    return;
                }

                _popupText.text = "Неверный логин или пароль";
                _popup.SetActive(true);
                _popupOkButton.onClick.AddListener(() => _popup.SetActive(false));
            }));
    }
}
