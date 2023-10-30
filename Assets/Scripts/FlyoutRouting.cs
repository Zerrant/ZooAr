using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyoutRouting : MonoBehaviour
{
    private const string PROFILE = "ProfileScene";
    private const string LIBRARY = "LibraryScene";
    private const string CAMERA = "SampleScene";

    private Scene _currentScene;

    private void Start() {
        _currentScene = SceneManager.GetActiveScene();
    }

    public void OnProfileClick() => ChangeScene(PROFILE);

    public void OnCameraClick() => ChangeScene(CAMERA);

    public void OnLibraryClick() => ChangeScene(LIBRARY);

    private void ChangeScene(string sceneName) {
        if (sceneName != _currentScene.name)
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
