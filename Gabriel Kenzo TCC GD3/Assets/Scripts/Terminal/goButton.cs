using UnityEngine;
using UnityEngine.SceneManagement;

public class goButton : MonoBehaviour
{
    int gridX, gridY, bigRooms, treasureRooms, lRooms, longRooms, reallyLongRooms, wideRooms, reallyWideRooms/*, puzzleRooms, armoryRooms*/;

    [SerializeField] private string sceneToLoad;
    public SceneController sceneController;

    private void Start()
    {
        if(sceneController == null) sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>();
    } 

    public void SetButton(Ship shipToSpawn)
    {
        gridX = shipToSpawn.gridX;
        gridY = shipToSpawn.gridY;
        bigRooms = shipToSpawn.bigRooms;
        treasureRooms = shipToSpawn.treasureRooms;
        lRooms = shipToSpawn.lRooms;
        longRooms = shipToSpawn.longRooms;
        reallyLongRooms = shipToSpawn.reallyLongRooms;
        wideRooms = shipToSpawn.wideRooms;
        reallyWideRooms = shipToSpawn.reallyWideRooms;
    }

    public void Go()
    {
        SendData();
        LoadScene(sceneToLoad);
    }

    private void SendData()
    {
        shipDataHolder.gridX = gridX;
        shipDataHolder.gridY = gridY;
        shipDataHolder.bigRooms = bigRooms;
        shipDataHolder.treasureRooms = treasureRooms;
        shipDataHolder.lRooms = lRooms;
        shipDataHolder.longRooms = longRooms;
        shipDataHolder.reallyLongRooms = reallyLongRooms;
        shipDataHolder.wideRooms = wideRooms;
        shipDataHolder.reallyWideRooms = reallyWideRooms;
    }
    
    public void LoadScene(string scene)
    {
        //sceneController.LoadScene(scene);
        SceneManager.LoadScene(scene);
    }
}
