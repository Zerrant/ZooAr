using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    [SerializeField] private AnimalDescriptionPanel _animalDescriptionPanel;
    [SerializeField] private GameObject _animalCardPrefab;
    [SerializeField] private RectTransform _panel;

    private List<GameObject> _drawIcons = new List<GameObject>();

    public TextAsset textJson;


    private void Start() => Redraw();
    
    private void Redraw()
    {
        ClearDrawn();
        StartCoroutine(HttpService.GetAnimalPage(animals =>
        {
            foreach (var animal in animals.data) {
                var icon = Instantiate(_animalCardPrefab);
                var animalCard = icon.GetComponent<AnimalCard>();

                animalCard.Animal = animal;
                animalCard.AnimalDescriptionPanel = _animalDescriptionPanel;

                icon.transform.localScale = new Vector3(3, 3, 3);
                icon.transform.SetParent(_panel);

                _drawIcons.Add(icon);

                var position = Vector2.zero;
                var row = 0;
                if (_drawIcons.Count % 2 == 0) {
                    position.x = 148;
                    row = _drawIcons.Count / 2;
                } else {
                    row = (_drawIcons.Count - 1) / 2;
                }

                position.y = row * 179;

                icon.transform.position = new(position.x, position.y, 0);
            }
        }));
    }

    private void ClearDrawn()
    {
        for (int i = 0; i < _drawIcons.Count; i++) {
            Destroy(_drawIcons[i]);
        }

        _drawIcons.Clear();
    }
}