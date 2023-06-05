using System;
using System.Security.Cryptography;
using UnityEngine;

public class AesKeyIVGenerator : MonoBehaviour
{
    public GameData testData;

    [SerializeField]
    private string KEY;
    [SerializeField]
    private string IV;
    [SerializeField]
    bool UseEncryption;

    private void Awake()
    {
        //TestSaveData();
    }

    [ContextMenu("Generate AES key and IV")]
    public void GeneratreAesKeyAndVI()
    {
        using Aes aesProvider = Aes.Create();
        KEY = Convert.ToBase64String(aesProvider.Key);
        IV = Convert.ToBase64String(aesProvider.IV);
    }

    [ContextMenu("Test save data")]
    public void TestSaveData()
    {
        IDataService dataService = new JsonDataService();
        dataService.SaveData<GameData>("Test.json", testData, UseEncryption);
        Debug.Log($"Data saved at: {Application.persistentDataPath} Test.json");
    }
    [ContextMenu("Test load data")]
    public void TestLoadData()
    {
        IDataService dataService = new JsonDataService();
        testData = dataService.LoadData<GameData>("Test.json", UseEncryption);
        Debug.Log($"Data loaded from: {Application.persistentDataPath} Test.json");
    }

}
