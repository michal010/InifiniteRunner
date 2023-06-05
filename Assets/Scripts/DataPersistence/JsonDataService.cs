using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class JsonDataService : IDataService
{
    private const string KEY = "DkuUFEIlokSdNJYeQKGF5ixMmDMgY4a9sr81dIjRlY4=";
    private const string IV = "EePDkyt6RYSBBkgS8sYxlQ==";

    public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, RelativePath);

        try
        {
            if(File.Exists(fullPath))
            {
                Debug.Log("File data: " + RelativePath + " already exists. Deleting old file and writing a new one!");
                File.Delete(fullPath);
            }
            else
            {
                Debug.Log("Writing file for the first time!");
            }
            using FileStream stream = File.Create(fullPath);
            if(Encrypted)
            {
                WriteEncryptedData(Data, stream);
            }
            else
            {
                stream.Close();
                File.WriteAllText(fullPath, JsonConvert.SerializeObject(Data));
            }
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
            return false;
        }

    }


    private void WriteEncryptedData<T>(T Data, FileStream Stream)
    {
        using Aes aesProvider = Aes.Create();
        aesProvider.Key = Convert.FromBase64String(KEY);
        aesProvider.IV = Convert.FromBase64String(IV);
        using ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor();
        using CryptoStream cryptoStream = new CryptoStream(
            Stream,
            cryptoTransform,
            CryptoStreamMode.Write
            );

        cryptoStream.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Data)));
    }

    public T LoadData<T>(string RelativePath, bool Encrypted)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, RelativePath);
        if (!File.Exists(fullPath))
        {
            Debug.LogError($"CAnnot load file at {fullPath}. File does not exist!");
            throw new FileNotFoundException($"{fullPath} does not exist!");
        }

        try
        {
            T data;
            if(Encrypted)
            {
                data = ReadEncryptedData<T>(fullPath);
            }
            else
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(fullPath));
            }
            return data;
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    private T ReadEncryptedData<T>(string FullPath)
    {
        byte[] fileBytes = File.ReadAllBytes(FullPath);
        using Aes aesProvider = Aes.Create();

        aesProvider.Key = Convert.FromBase64String(KEY);
        aesProvider.IV = Convert.FromBase64String(IV);

        using ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(
                aesProvider.Key,
                aesProvider.IV
            );
        using MemoryStream decryptionStream = new MemoryStream(fileBytes);
        using CryptoStream cryptoStream = new CryptoStream(
            decryptionStream,
            cryptoTransform,
            CryptoStreamMode.Read
            );
        using StreamReader reader = new StreamReader(cryptoStream);

        string result = reader.ReadToEnd();

        Debug.Log($"Decrypted result (if the following is not legible, probably wrong key or iv): {result}");

        return JsonConvert.DeserializeObject<T>(result);
    }

}
