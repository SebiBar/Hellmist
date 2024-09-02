using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private readonly static string savePath = Application.persistentDataPath + "/playerData.json";

    public static void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        return null;
    }
}