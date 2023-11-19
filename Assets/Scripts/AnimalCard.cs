using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalCard : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _animalCardUI;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _animalImage;
    [SerializeField] private Button _previewButton;
    [SerializeField] private string _previewScene;
    [Header("Animal")]
    [SerializeField] private string _animalName;

    Animal _animal = new Animal();
    GameObject animalDescriptionPanel;

    

    public void OpenAnimalDescription() {
        animalDescriptionPanel.GetComponent<AnimalDescriptionPanel>().SetAnimalDescription(_animal, _animalImage, _previewScene);
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

    public void SetAnimalDescriptionPanel(GameObject ADP)
    {
        animalDescriptionPanel = ADP;
    }
}
