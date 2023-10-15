using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Осуществление регистрации пользователя.
/// </summary>
public class Register : MonoBehaviour
{
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_InputField _repeatPassword;
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _popupText;
    [SerializeField] private Button _popupOkButton;

    /// <summary>
    /// Обработать нажатие на кнопку регистрацияю.
    /// </summary>
    public void OnRegisterClick() {
        if (string.IsNullOrWhiteSpace(_login.text) || string.IsNullOrWhiteSpace(_login.text) || string.IsNullOrWhiteSpace(_login.text)) {
            _popupText.text = "Некоторые поля не заполнены";
            _popup.SetActive(true);
            _popupOkButton.onClick.AddListener(() => _popup.SetActive(false));
            return;
        }

        if (_password.text != _repeatPassword.text) {
            _popupText.text = "Пароли должны совподать";
            _popup.SetActive(true);
            _popupOkButton.onClick.AddListener(() => _popup.SetActive(false));
            return;
        }

        var usersData = SavingService.LoadData();

        usersData ??= new() { Users = new List<User>() };

        if (usersData.Users.Any(user => user.Login == _login.text)) {
            _popupText.text = "Пользователь с таким именем уже существует";
            _popup.SetActive(true);
            _popupOkButton.onClick.AddListener(() => _popup.SetActive(false));
            return;
        }

        usersData.Users.Add(new User() {
            Login = _login.text,
            Password = _password.text
        });

        SavingService.SaveData(usersData);
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }
}
