using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPreview : MonoBehaviour
{
    [SerializeField] private GameObject _statusPopup;

    private void Start() {
        _statusPopup.SetActive(true);
        StartCoroutine(HttpService.GetAssetBundle(CurrentAnimal.AnimalId, assetBundle => {
            var asset = assetBundle.LoadAsset<GameObject>(CurrentAnimal.AssetBundleGameobject);
            Instantiate(asset);

            _statusPopup.SetActive(false);
        }));
    }

    public void OnExitClick() {
        SceneManager.LoadSceneAsync("ProfileScene", LoadSceneMode.Single);
    }
}
