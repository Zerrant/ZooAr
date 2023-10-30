using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SavingService
{
    private static readonly string userFilePath = Application.persistentDataPath + "/usersdata.json";
    private static readonly string animalFilePath = Application.persistentDataPath + "/animals.json";

    public static void SaveData<T>(T entity) {
        var type = entity.GetType();
        var filePath = type.Name switch {
            nameof(User) => userFilePath,
            nameof(Animal) => animalFilePath,
            _ => string.Empty
        };

        try {
            var data = LoadData<T>();
            data.Entities.Add(entity);

            using var stream = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(stream);

            writer.Write(JsonUtility.ToJson(data, true));
        } catch (Exception ex) {
            Debug.LogException(ex);
        }
    }

    public static Data<T> LoadData<T>() {
        var type = typeof(T);
        var filePath = type.Name switch {
            nameof(User) => userFilePath,
            nameof(Animal) => animalFilePath,
            _ => string.Empty
        };

        if (!File.Exists(filePath)) {
            return new Data<T>() { Entities = new List<T>() };
        }

        var dataToLoad = string.Empty;

        try {
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            using var reader = new StreamReader(stream);

            dataToLoad = reader.ReadToEnd();
        } catch (Exception ex) {
            Debug.LogException(ex);
        }

        return dataToLoad != string.Empty
            ? JsonUtility.FromJson<Data<T>>(dataToLoad)
            : new Data<T>() { Entities = new List<T>() };
    }
}
