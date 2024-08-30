using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/playerData.json";

    public static void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    private static PlayerData LoadPlayerData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return new PlayerData();  // Return a new instance with default values
        }
    }

    public static void LoadAndApplyPlayerData()
    {
        PlayerData loadedData = LoadPlayerData();

        if (loadedData != null && PlayerData.Instance != null)
        {
            PlayerData.Instance.PlayerClass = loadedData.PlayerClass;
            // Apply other player data as needed
        }
    }
}