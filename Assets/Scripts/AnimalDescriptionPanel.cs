using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalDescriptionPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _weight;
    [SerializeField] private TMP_Text _length;
    [SerializeField] private TMP_Text _width;
    [SerializeField] private Image _image;
    [SerializeField] private Button _previewButton;

    public void SetAnimalDescription(Animal animal, Sprite animalSprite, string previewScene)
    {
        _name.text = animal.name;
        _weight.text = animal.weight;
        _length.text = animal.length;
        _width.text = animal.width;
        _image.sprite = animalSprite;
        _previewButton.onClick.RemoveAllListeners();
        _previewButton.onClick.AddListener(() => SceneManager.LoadSceneAsync(previewScene, LoadSceneMode.Single));

        gameObject.SetActive(true);
    }
}
