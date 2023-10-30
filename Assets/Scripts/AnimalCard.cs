using System.Linq;
using TMPro;
using UnityEngine;
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
    [Header("Animal")]
    [SerializeField] private string _animalName;

    private Animal _animal;

    private void Start() {
        var data = SavingService.LoadData<Animal>();
        _animal = data.Entities.First(entity => entity.Name == _animalName);
    }

    public void OpenAnimalDescription() {
        _name.text = _animal.Name;
        _weight.text = $"~{_animal.Weight:f1}";
        _length.text = $"{_animal.Length:f0} ì.";
        _width.text = $"{_animal.Width:f0} ì.";
        _image.sprite = _animalImage;

        _animalCardUI.SetActive(true);
    }
}
