using System.Collections;
using System.Collections.Generic;
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
        _name.text = animal.Name;
        _weight.text = $"~{animal.Weight:f1}";
        _length.text = $"{animal.Length:f0} ì.";
        _width.text = $"{animal.Width:f0} ì.";
        _image.sprite = animalSprite;
        _previewButton.onClick.RemoveAllListeners();
        _previewButton.onClick.AddListener(() => SceneManager.LoadSceneAsync(previewScene, LoadSceneMode.Single));

        gameObject.SetActive(true);
    }
}
