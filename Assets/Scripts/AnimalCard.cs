using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimalCard : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _image;
    [SerializeField] private string _previewScene;

    public AnimalDescriptionPanel AnimalDescriptionPanel { set => _animalDescriptionPanel = value; }
    public Animal Animal { 
        set {
            _animal.id = value.id;
            _animal.name = value.name;
            _animal.length = value.length;
            _animal.width = value.width;
            _animal.weight = value.weight;
            _animal.description = value.description;
            _animal.assetBundleGameobject = value.assetBundleGameobject;

            StartCoroutine(HttpService.GetPreview(_animal.id, texture => {
                _animalPreviewSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new(0.5f, 0.5f), 100);
                _image.sprite = _animalPreviewSprite;
            }));
        }
    }

    private Animal _animal = new();
    private AnimalDescriptionPanel _animalDescriptionPanel;
    private Sprite _animalPreviewSprite;

    public void OpenAnimalDescription() => _animalDescriptionPanel.SetAnimalDescription(_animal, _animalPreviewSprite, _previewScene);

    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => OpenAnimalDescription());
    }
}
