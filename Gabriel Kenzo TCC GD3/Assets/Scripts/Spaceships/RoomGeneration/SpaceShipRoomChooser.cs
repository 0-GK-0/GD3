using System.Collections.Generic;
using UnityEngine;

public class SpaceShipRoomChooser : MonoBehaviour
{
    private List<Vector2> unusedRooms = new List<Vector2>();
    [SerializeField] private int ammountOfTreasureRooms;

    [SerializeField] private List<GameObject> treasureRoomModels, normalRoomModels, bossRoomModels, enemyGroupsList;
    [SerializeField] private string spawnerTag = "enemySpawner";

    
    public void ListRooms(List<Vector2> roomsToUse)
    {
        unusedRooms = roomsToUse;
        
        PlacePlayer();
        ChooseBossRoom();
        ChooseTreasureRooms();

        ChooseRestOfRooms();

        GenerateEnemies();
    }

    public void PlacePlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");

        player.transform.position = unusedRooms[0];
        Debug.Log("PlayerTPd");
    }

    private void ChooseBossRoom()
    {
        int randomBoss = Random.Range(0, bossRoomModels.Count);

        Instantiate(bossRoomModels[randomBoss], unusedRooms[unusedRooms.Count-1], Quaternion.identity);
        unusedRooms.RemoveAt(unusedRooms.Count-1);
    }

    private void ChooseTreasureRooms()
    {
        for(int i = 0; i < ammountOfTreasureRooms; i++)
        {
            int randomRoom = Random.Range(1, unusedRooms.Count);
            int randomTreasure = Random.Range(0, treasureRoomModels.Count);

            Instantiate(treasureRoomModels[randomTreasure], unusedRooms[randomRoom], Quaternion.identity);
            unusedRooms.RemoveAt(randomRoom);
        }
    }

    private void ChooseRestOfRooms()
    {
        for(int i = 1; i < unusedRooms.Count; i++)
        {
            int randomRoom = Random.Range(0, treasureRoomModels.Count);

            Instantiate(normalRoomModels[randomRoom], unusedRooms[i], Quaternion.identity);
            unusedRooms.RemoveAt(i);
        }
        Debug.Log("AllRoomsFilled");
    }

    private void GenerateEnemies()
    {
        GameObject[] enemySpawners = GameObject.FindGameObjectsWithTag(spawnerTag);

        foreach(GameObject obj in enemySpawners)
        {
            int randomEnemy = Random.Range(0, enemyGroupsList.Count);
            
            Instantiate(enemyGroupsList[randomEnemy], obj.transform.position, Quaternion.identity);
            Destroy(obj);
        }
        Debug.Log("EnemiesGenerated");
    }
}
