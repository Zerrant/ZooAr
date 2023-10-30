using System;
using UnityEngine;

[Obsolete("Убрать нахуй это говно")]
public class LabraryKostyl : MonoBehaviour
{
    [SerializeField] private GameObject _tRexCard;
    [SerializeField] private GameObject _pterodactylCard;
    [SerializeField] private GameObject _parazavrCard;

    private void Start() {
        _tRexCard.SetActive(false);
        _pterodactylCard.SetActive(false);
        _parazavrCard.SetActive(false);

        var data = SavingService.LoadData<Animal>();
        foreach (var entity in data.Entities) {
            switch (entity.Name) {
                case "T-Rex":
                    _tRexCard.SetActive(true);
                    break;

                case "Ptyrodactil":
                    _pterodactylCard.SetActive(true);
                    break;

                case "Parasaurolof":
                    _parazavrCard.SetActive(true);
                    break;
            }
        }
    }
}
