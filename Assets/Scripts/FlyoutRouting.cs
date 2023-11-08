using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyoutRouting : MonoBehaviour
{
    [SerializeField] private GameObject _profilePanel;
    [SerializeField] private GameObject _libraryPanel;
    [SerializeField] private GameObject _animalPanel;

    private const string PROFILE = "ProfileScene";
    private const string CAMERA = "SampleScene";

    private Scene _currentScene;

    private void Start() {
        _currentScene = SceneManager.GetActiveScene();
        _profilePanel.SetActive(true);
        _libraryPanel.SetActive(false);
        _animalPanel.SetActive(false);
    }

    public void OnProfileClick() {
        if (_profilePanel == null) {
            ChangeScene(PROFILE);
            return;
        }

        if (_profilePanel.activeSelf) return;

        _profilePanel.SetActive(true);
        _libraryPanel.SetActive(false);
        _animalPanel.SetActive(false);
    }

    public void OnLibraryClick() {
        _profilePanel.SetActive(false);
        _libraryPanel.SetActive(true);
    }

    public void OnCameraClick() => ChangeScene(CAMERA);

    private void ChangeScene(string sceneName) {
        if (sceneName != _currentScene.name)
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
