using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeActivation : MonoBehaviour {
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TMP_Text _statusLabel;
    [SerializeField] private Button _button;

    private void Start() {
        _button.onClick.AddListener(() => {
            var code = _input.text;
            if (code.Length != 12) {
                _statusLabel.text = "Код активации должен состоять из 12 символов!";
                return;
            }

            StartCoroutine(HttpService.ActivateCard(code, status => {
                if (status >= 200 || status < 300) {
                    _statusLabel.text = "Код успешно активирован!";
                } else {
                    _statusLabel.text = "Упс, что-то пошло не так (μ_μ)";
                }
            }));
        });
    }
}
