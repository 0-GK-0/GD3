using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Rooms")]
    public GameObject roomPrefab;
    public int roomAmmount;
    public float roomDist;

    private List<Vector2> usedPos = new List<Vector2>();
    private Vector2 currentPos;

    [Header("Walls")]
    [SerializeField] private GameObject wallW, wallS, wallA, wallD, doorW, doorS, doorA, doorD;

    private void Start()
    {
        currentPos = Vector2.zero;
        usedPos.Add(currentPos);

        Instantiate(roomPrefab, currentPos, Quaternion.identity);

        for(int i = 0; i < roomAmmount; i++)
        {
            CreateRoom();
        }
    }
    private void CreateRoom()
    {
        var newPos = currentPos;
        int direction = Random.Range(0, 4);

        switch(direction)
        {
            case 0: newPos += Vector2.up * roomDist;
            if(newPos != usedPos[0]){
                Instantiate(doorW, currentPos, Quaternion.identity);
                Instantiate(doorS, newPos, Quaternion.identity);
            }
            break;
            case 1: newPos += Vector2.down * roomDist;
            if(newPos != usedPos[0]){
                Instantiate(doorS, currentPos, Quaternion.identity);
                Instantiate(doorW, newPos, Quaternion.identity);
            }
            break;
            case 2: newPos += Vector2.left * roomDist;
            if(newPos != usedPos[0]){
                Instantiate(doorA, currentPos, Quaternion.identity);
                Instantiate(doorD, newPos, Quaternion.identity);
            }
            break;
            case 3: newPos += Vector2.right * roomDist;
            if(newPos != usedPos[0]){
                Instantiate(doorD, currentPos, Quaternion.identity);
                Instantiate(doorA, newPos, Quaternion.identity);
            }
            break;
        }
        if (!usedPos.Contains(newPos))
        {
            Instantiate(roomPrefab, newPos, Quaternion.identity);
            Instantiate(wallW, newPos, Quaternion.identity);
            Instantiate(wallS, newPos, Quaternion.identity);
            Instantiate(wallA, newPos, Quaternion.identity);
            Instantiate(wallD, newPos, Quaternion.identity);
            usedPos.Add(newPos);
            currentPos = newPos;
        }
    }
}
