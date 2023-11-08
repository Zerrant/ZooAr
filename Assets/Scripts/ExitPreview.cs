using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Obsolete("»зменить переходы по страницам на адекватные")]
public class ExitPreview : MonoBehaviour
{
    public void OnExitClick() {
        SceneManager.LoadSceneAsync("ProfileScene", LoadSceneMode.Single);
    }
}
