using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipGen : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridY;
    public float gridSpacingOffset = 16f;
    public Vector2 gridOrigin = Vector2.zero;

    [Header("Temporary Walls")]
    [SerializeField] private GameObject wallW, wallA, wallS, wallD;

    [Header("Door Generation")]
    [SerializeField] private List<Vector2> roomPos;
    [SerializeField] private List<Vector2> borderRoomPos;
    [SerializeField] private GameObject doorW, doorA, doorS, doorD;
    float timer = 40f;
    private List<Vector2> usedPos = new List<Vector2>();

    [Header("Room Chooser")]
    [SerializeField] private SpaceShipRoomChooser roomChooser;

    private void Start()
    {
        SpawnGrid();
        GenerateDoors();
        roomChooser.ListRooms(usedPos, gridSpacingOffset);
    }
    //Grid
    private void SpawnGrid()
    {
        for(int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector2 spawnPos = new Vector2(x * gridSpacingOffset, y * gridSpacingOffset) + gridOrigin;
                roomPos.Add(spawnPos);
                if(x == 0 || y == 0 || x == gridX || y == gridY)
                {
                    borderRoomPos.Add(spawnPos);
                }
                PickAndSpawn(spawnPos, Quaternion.identity);
            }
        }
    }
    private void PickAndSpawn(Vector3 spawnPos, Quaternion spawnRot)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        Instantiate(itemsToPickFrom[randomIndex], spawnPos, spawnRot);

        var w = Instantiate(wallW, spawnPos, spawnRot);
        var a = Instantiate(wallA, spawnPos, spawnRot);
        var s =Instantiate(wallS, spawnPos, spawnRot);
        var d =Instantiate(wallD, spawnPos, spawnRot);
    }

    //Doors
    private void GenerateDoors()
    {
        Vector2 startingPos = GetRandomBorderRoom();
        Vector2 currentPos = startingPos;
        Vector2 previousPos = Vector2.zero;

        while (roomPos.Count > 0){
            if(timer > 0)
            {
                if(roomPos.Contains(currentPos))
                {
                    roomPos.Remove(currentPos);
                    if(usedPos.Contains(previousPos)) usedPos.Insert(usedPos.IndexOf(previousPos)+1, currentPos);
                    else usedPos.Add(currentPos);
                }

                Vector3 neighbour = ChooseNeighbour(currentPos);
                float dir = neighbour.z;
                Vector2 nextPos = new Vector2(neighbour.x, neighbour.y);

                /*Debug.Log(currentPos);
                Debug.Log(dir);
                Debug.Log(nextPos);*/

                switch (dir)
                {
                    case 1:
                        Instantiate(doorW, currentPos, Quaternion.identity);
                        Instantiate(doorS, nextPos, Quaternion.identity);
                        previousPos = currentPos;
                        currentPos = nextPos;
                        break;
                    case 2:
                        Instantiate(doorA, currentPos, Quaternion.identity);
                        Instantiate(doorD, nextPos, Quaternion.identity);
                        previousPos = currentPos;
                        currentPos = nextPos;
                        break;
                    case 3:
                        Instantiate(doorS, currentPos, Quaternion.identity);
                        Instantiate(doorW, nextPos, Quaternion.identity);
                        previousPos = currentPos;
                        currentPos = nextPos;
                        break;
                    case 4:
                        Instantiate(doorD, currentPos, Quaternion.identity);
                        Instantiate(doorA, nextPos, Quaternion.identity);
                        previousPos = currentPos;
                        currentPos = nextPos;
                        break;
                    case -1:
                        if(usedPos.Count > 1)
                        {
                            currentPos = usedPos[usedPos.IndexOf(currentPos)-1];
                            previousPos = currentPos;
                        }
                        else roomPos.Clear();
                        break;
                }
                //timer -= 1;
            }
            else roomPos.Clear();
        }
    }

    private Vector2 GetRandomBorderRoom()
    {
        int randomRoom = Random.Range(0, borderRoomPos.Count);
        return borderRoomPos[randomRoom];
    }
    private Vector3 ChooseNeighbour(Vector2 pos)
    {
        Vector2 neighbourW = new Vector2(pos.x, pos.y + gridSpacingOffset);
        Vector2 neighbourA = new Vector2(pos.x - gridSpacingOffset, pos.y);
        Vector2 neighbourS = new Vector2(pos.x, pos.y - gridSpacingOffset);
        Vector2 neighbourD = new Vector2(pos.x + gridSpacingOffset, pos.y);

        List<Vector2> possibleNeighbours = new List<Vector2>();
        List<int> dir = new List<int>();

        if (roomPos.Contains(neighbourW))
        {
            possibleNeighbours.Add(neighbourW);
            dir.Add(1);
        }
        if (roomPos.Contains(neighbourA))
        {
            possibleNeighbours.Add(neighbourA);
            dir.Add(2);
        }
        if (roomPos.Contains(neighbourS))
        {
            possibleNeighbours.Add(neighbourS);
            dir.Add(3);
        }
        if (roomPos.Contains(neighbourD))
        {
            possibleNeighbours.Add(neighbourD);
            dir.Add(4);
        }

        if(possibleNeighbours.Count > 0)
        {
            int randomNeighbour = Random.Range(0, possibleNeighbours.Count);
            return new Vector3(possibleNeighbours[randomNeighbour].x, possibleNeighbours[randomNeighbour].y, dir[randomNeighbour]);
        }
        else
        {
            return new Vector3(0, 0, -1);
        }
    }
}
