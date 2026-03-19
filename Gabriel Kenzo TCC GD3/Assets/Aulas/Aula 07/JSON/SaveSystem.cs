using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    string path;
    
    private void Start()
    {
        path = Application.persistentDataPath + "/save.json";
    }
    public void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log("Salvando em: " + path);
    }
    public PlayerData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return null;
        }
    }
}
