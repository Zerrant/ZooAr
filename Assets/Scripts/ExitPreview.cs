using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPreview : MonoBehaviour
{
    public void OnExitClick() {
        SceneManager.LoadSceneAsync("ProfileScene", LoadSceneMode.Single);
    }
}
