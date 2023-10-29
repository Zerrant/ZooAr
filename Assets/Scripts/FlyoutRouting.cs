using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyoutRouting : MonoBehaviour {
    [SerializeField] private string _profileScene;

    public void OnProfileClick() {
        var activeScene = SceneManager.GetActiveScene();

        if (activeScene.name != _profileScene)
            SceneManager.LoadSceneAsync(_profileScene, LoadSceneMode.Single);
    }
}
