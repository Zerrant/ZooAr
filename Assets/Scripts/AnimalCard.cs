using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalCard : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _animalCardUI;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _weight;
    [SerializeField] private TMP_Text _length;
    [SerializeField] private TMP_Text _width;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _animalImage;
    [SerializeField] private Button _previewButton;
    [SerializeField] private string _previewScene;
    [Header("Animal")]
    [SerializeField] private string _animalName;

    public Animal _animal = new Animal();

    //private void Start()
    //{
    //    var data = SavingService.LoadData<Animal>();
    //    _animal = data.Entities.First(entity => entity.Name == _animalName);
    //}

    public void OpenAnimalDescription() {
        GameObject animalDescriptionPanel = GameObject.Find("AnimalDescriptionPanel");

        animalDescriptionPanel.transform.Find("Name").GetComponent<TextMeshPro>().text = _animal.Name;
        animalDescriptionPanel.transform.Find("Weight").GetComponent<TextMeshPro>().text = $"~{_animal.Weight:f1}";
        animalDescriptionPanel.transform.Find("Length").GetComponent<TextMeshPro>().text = $"{_animal.Length:f0} �.";
        animalDescriptionPanel.transform.Find("Width").GetComponent<TextMeshPro>().text = $"{_animal.Width:f0} �.";
        animalDescriptionPanel.transform.Find("AnimalImage").GetComponent<Image>().sprite  = _animalImage;
        animalDescriptionPanel.transform.Find("Preview").GetComponent<Button>().onClick.RemoveAllListeners();
        animalDescriptionPanel.transform.Find("Preview").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadSceneAsync(_previewScene, LoadSceneMode.Single));
        //_name.text = _animal.Name;
        //_weight.text = $"~{_animal.Weight:f1}";
        //_length.text = $"{_animal.Length:f0} �.";
        //_width.text = $"{_animal.Width:f0} �.";
        //_image.sprite = _animalImage;
        //_previewButton.onClick.RemoveAllListeners();
        //_previewButton.onClick.AddListener(() => SceneManager.LoadSceneAsync(_previewScene, LoadSceneMode.Single));

        _animalCardUI.SetActive(true);
    }

    public string GetAnimalName()
    {
        return _animalName;
    }

    public void SetAnimal(Animal animal)
    {
        _animal.Name = animal.Name;
        _animal.Length = animal.Length;
        _animal.Width = animal.Width;
        _animal.Weight = animal.Weight;
        _animal.StructureDescription = animal.StructureDescription;
    }
}
