using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ������������� ����� � ������� ������ ������������.
/// </summary>
public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _popupText;
    [SerializeField] private Button _popupOkButton;

    /// <summary>
    /// ����������� ���� � ������� ������ ��� ������� �� ������ �����.
    /// </summary>
    public void OnLoginClicked() {
        var usersData = SavingService.LoadData();
        var user = usersData.Users.FirstOrDefault(user => user.Login == _login.text && user.Password == _password.text);

        if (user != null) {
            SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
            return;
        }

        _popupText.text = "�������� ����� ��� ������";
        _popup.SetActive(true);
        _popupOkButton.onClick.AddListener(() => _popup.SetActive(false));
    }
}