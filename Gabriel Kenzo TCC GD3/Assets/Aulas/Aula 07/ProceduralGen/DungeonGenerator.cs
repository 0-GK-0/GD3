using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int roomAmmount;
    public float roomDist;

    private List<Vector2> usedPos = new List<Vector2>();
    private Vector2 currentPos;

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
            case 0: newPos += Vector2.up * roomDist; break;
            case 1: newPos += Vector2.down * roomDist; break;
            case 2: newPos += Vector2.left * roomDist; break;
            case 3: newPos += Vector2.right * roomDist; break;
        }
        if (!usedPos.Contains(newPos))
        {
            Instantiate(roomPrefab, newPos, Quaternion.identity);
            usedPos.Add(newPos);
            currentPos = newPos;
        }
    }
}
