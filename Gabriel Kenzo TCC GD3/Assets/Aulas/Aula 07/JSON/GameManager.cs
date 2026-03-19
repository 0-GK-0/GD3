using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveSystem saveSystem;
    public Transform pTransform;
    public int money = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Save();
        if (Input.GetKeyDown(KeyCode.L)) Load();
    }

    void Save()
    {
        PlayerData data = new PlayerData();
        data.name = name;
        data.money = money;

        data.posX = pTransform.position.x;
        data.posY = pTransform.position.y;
        data.posZ = pTransform.position.z;

        saveSystem.Save(data);
    }

    void Load()
    {
        PlayerData data = saveSystem.Load();
        if(data != null)
        {
            name = data.name;
            money = data.money;
            Vector3 pos = new Vector3(data.posX, data.posY, data.posZ);
            pTransform.position = pos;
            Debug.Log("Loaded");
        }
        else Debug.Log("Null data");
    }
}
