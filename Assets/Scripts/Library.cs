using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Library : MonoBehaviour
{
    [SerializeField] private List<GameObject> _animalsPrefabs;
    [SerializeField] private GameObject _animalDescriptionPanel;
    [SerializeField] private RectTransform _panel;
    private Data<Animal> _animalsList;
    private List<GameObject> _drawIcons = new List<GameObject>();

    public TextAsset textJson;


    private void Start()
    {
        Redraw();
    }
    
    private void Redraw()
    {
        ClearDrawn();
        _animalsList = SavingService.LoadData<Animal>();
        _animalsList.Entities.Add(new Animal { Name = "T-Rex", Weight = 3f, Length = 3f, Width = 3f, StructureDescription ="Динозавр"});
        _animalsList.Entities.Add(new Animal { Name = "Parasaurolof", Weight = 1f, Length = 1f, Width = 1f, StructureDescription = "Динозавр" });
        if (_animalsList.Entities.Count == 0) return;


        foreach (var entity in _animalsList.Entities)
        {
            foreach (var animalprefab in _animalsPrefabs)
            {
                if (entity.Name == animalprefab.GetComponent<AnimalCard>()?.GetAnimalName()) //проверка происходит если у префаба есть компонент AnimalCard
                {
                    GameObject icon = Instantiate(animalprefab);
                    icon.GetComponent<AnimalCard>().SetAnimal(entity);
                    icon.GetComponent<AnimalCard>().SetAnimalDescriptionPanel(_animalDescriptionPanel);
                    icon.transform.localScale = new Vector3(4,4,4);
                    icon.transform.SetParent(_panel);

                    _drawIcons.Add(icon);
                    break;
                }
            }
        }
    }

    private void ClearDrawn()
    {
        for (int i = 0; i < _drawIcons.Count; i++)
        {
            Destroy(_drawIcons[i]);
        }
        //_animalsList.Entities.Clear();
        _drawIcons.Clear();
    }
}