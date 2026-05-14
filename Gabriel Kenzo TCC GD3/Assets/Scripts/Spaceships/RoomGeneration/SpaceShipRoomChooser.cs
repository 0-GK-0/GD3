using System.Collections.Generic;
using UnityEngine;

public class SpaceShipRoomChooser : MonoBehaviour
{
    private List<Vector2> unusedRooms = new List<Vector2>();
    public int ammountOfTreasureRooms, ammountOfBigRooms, ammountOfTallRooms, ammountOfTallerRooms, ammountOfWideRooms, ammountOfWiderRooms, ammountOfLRooms;

    [SerializeField] private List<GameObject> treasureRoomModels, normalRoomModels, bossRoomModels, enemyGroupsList, bigRoomModels, tallRoomModels, tallerRoomModels, wideRoomModels, widerRoomModels, l1RoomModels, l2RoomModels, l3RoomModels, l4RoomModels;
    [SerializeField] private string spawnerTag = "enemySpawner";
    public string endingRoomTpDestination;
    private float gridSpacingOffset;

    
    public void ListRooms(List<Vector2> roomsToUse, float roomSize)
    {
        unusedRooms = roomsToUse;
        gridSpacingOffset = roomSize;
        
        PlacePlayer();

        ChooseBossRoom();

        Choose2x2Rooms();
        Choose3x1Rooms();
        Choose1x3Rooms();
        ChooseLRooms();
        Choose2x1Rooms();
        Choose1x2Rooms();

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
    }

    private void ChooseTreasureRooms()
    {
        for(int i = 0; i < ammountOfTreasureRooms; i++)
        {
            int randomRoom = Random.Range(1, unusedRooms.Count - 1);
            int randomTreasure = Random.Range(0, treasureRoomModels.Count);

            Instantiate(treasureRoomModels[randomTreasure], unusedRooms[randomRoom], Quaternion.identity);
            unusedRooms.RemoveAt(randomRoom);
        }
    }
    
    private List<Vector3> CheckNeigbours(List<Vector2> possibleRooms, int randomRoom, bool checkCorners, List<Vector2> unusedRooms, int crossCheck)
    {   
        List<Vector2> possibleNeighbours = new List<Vector2>();
        List<int> dir = new List<int>();

        if(crossCheck == 1 || crossCheck == 3)
        {
            Vector2 neighbourW = new Vector2(possibleRooms[randomRoom].x, possibleRooms[randomRoom].y + gridSpacingOffset);
            Vector2 neighbourS = new Vector2(possibleRooms[randomRoom].x, possibleRooms[randomRoom].y - gridSpacingOffset);
            if (unusedRooms.Contains(neighbourW))
            {
                possibleNeighbours.Add(neighbourW);
                dir.Add(1);
            }
            if (unusedRooms.Contains(neighbourS))
            {
                possibleNeighbours.Add(neighbourS);
                dir.Add(3);
            }
        } 
        if(crossCheck == 2 || crossCheck == 3)
        {
            Vector2 neighbourA = new Vector2(possibleRooms[randomRoom].x - gridSpacingOffset, possibleRooms[randomRoom].y);
            Vector2 neighbourD = new Vector2(possibleRooms[randomRoom].x + gridSpacingOffset, possibleRooms[randomRoom].y);
            if (unusedRooms.Contains(neighbourA))
            {
                possibleNeighbours.Add(neighbourA);
                dir.Add(2);
            }  
            if (unusedRooms.Contains(neighbourD))
            {
                possibleNeighbours.Add(neighbourD);
                dir.Add(4);
            }
        }


        if (checkCorners)
        {
            Vector2 neighbourWA = new Vector2(possibleRooms[randomRoom].x - gridSpacingOffset, possibleRooms[randomRoom].y + gridSpacingOffset);
            Vector2 neighbourWD = new Vector2(possibleRooms[randomRoom].x + gridSpacingOffset, possibleRooms[randomRoom].y + gridSpacingOffset);
            Vector2 neighbourSA = new Vector2(possibleRooms[randomRoom].x - gridSpacingOffset, possibleRooms[randomRoom].y - gridSpacingOffset);
            Vector2 neighbourSD = new Vector2(possibleRooms[randomRoom].x + gridSpacingOffset, possibleRooms[randomRoom].y - gridSpacingOffset);
            if (unusedRooms.Contains(neighbourWA))
            {
                possibleNeighbours.Add(neighbourWA);
                dir.Add(5);
            }
            if (unusedRooms.Contains(neighbourWD))
            {
                possibleNeighbours.Add(neighbourWD);
                dir.Add(6);
            }
            if (unusedRooms.Contains(neighbourSA))
            {
                possibleNeighbours.Add(neighbourSA);
                dir.Add(7);
            }
            if (unusedRooms.Contains(neighbourSD))
            {
                possibleNeighbours.Add(neighbourSD);
                dir.Add(8);
            }
        }

        List<Vector3> returnValue = new List<Vector3>();

        for (int i = 0; i < dir.Count; i++)
        {
            returnValue.Add(new Vector3(possibleNeighbours[i].x, possibleNeighbours[i].y, dir[i]));
        }

        //Debug.Log("Working. Count: " + returnValue.Count);
        return returnValue;
    }
    private List<Vector2> AvailableRoomsList(bool checkCorners, int crossCheck)
    {
        List<Vector2> possibleRooms = new List<Vector2>(unusedRooms);

        List<Vector3> startingNeighbours = CheckNeigbours(unusedRooms, 0, checkCorners, unusedRooms, crossCheck);
        for (int i = 0; i < startingNeighbours.Count; i++)
        {
            if(possibleRooms.Contains(new Vector2(startingNeighbours[i].x, startingNeighbours[i].y)))
                possibleRooms.Remove(new Vector2(startingNeighbours[i].x, startingNeighbours[i].y));
        }
        possibleRooms.RemoveAt(0);

        List<Vector3> endingNeighbours = CheckNeigbours(unusedRooms, unusedRooms.Count - 1, checkCorners, unusedRooms, crossCheck);
        for (int i = 0; i < endingNeighbours.Count; i++)
        {
            if(possibleRooms.Contains(new Vector2(endingNeighbours[i].x, endingNeighbours[i].y)))
            {
                possibleRooms.Remove(new Vector2(endingNeighbours[i].x, endingNeighbours[i].y));
                //Debug.Log("Removed: n° " + i + ", pos: " + new Vector2(endingNeighbours[i].x, endingNeighbours[i].y));
            }
        }
        possibleRooms.RemoveAt(possibleRooms.Count - 1);

        return possibleRooms;
    }
    private List<int> GetNeighboursDirections(List<Vector3> neighbours)
    {
        List<int> dir = new List<int>();
        for (int i = 0; i < neighbours.Count; i++)
            dir.Add(Mathf.RoundToInt(neighbours[i].z));
        return dir;
    }

    private void Choose2x2Rooms()
    {
        for (int a = 0; a < ammountOfBigRooms; a++)
        {
            List<Vector2> possibleRooms = AvailableRoomsList(true, 3);
            
            List<int> possibleDir = new List<int>();
            Vector2 room = new Vector2();
            Vector2 room2 = new Vector2();
            Vector2 room3 = new Vector2();
            Vector2 room4 = new Vector2();
            bool foundRoom = false;

            Debug.Log("PossibleRooms Count: " + possibleRooms.Count);

            while (!foundRoom && possibleRooms.Count > 0){
                Debug.Log("while initiated");
                int randomRoom = Random.Range(0, possibleRooms.Count);

                List<Vector3> neighbours = CheckNeigbours(possibleRooms, randomRoom, true, unusedRooms, 3);
                List<int> dir = GetNeighboursDirections(neighbours);
                
                /*
                125 - upper left corner
                146 - upper right corner
                237 - lower left corner
                348 - lower right corner
                */
                if (dir.Contains(1) && dir.Contains(2) && dir.Contains(5) || dir.Contains(1) && dir.Contains(4) && dir.Contains(6) || dir.Contains(2) && dir.Contains(3) && dir.Contains(7) || dir.Contains(3) && dir.Contains(4) && dir.Contains(8))
                {
                    if (dir.Contains(1) && dir.Contains(2) && dir.Contains(5))
                    {
                        foundRoom = true;
                        possibleDir.Add(1);
                        room = possibleRooms[randomRoom];
                    }
                    else if (dir.Contains(1) && dir.Contains(4) && dir.Contains(6))
                    {
                        foundRoom = true;
                        possibleDir.Add(2);
                        room = possibleRooms[randomRoom];
                    }
                    else if (dir.Contains(2) && dir.Contains(3) && dir.Contains(7))
                    {
                        foundRoom = true;
                        possibleDir.Add(3);
                        room = possibleRooms[randomRoom];
                    }
                    else if (dir.Contains(3) && dir.Contains(4) && dir.Contains(8))
                    {
                        foundRoom = true;
                        possibleDir.Add(4);
                        room = possibleRooms[randomRoom];
                    }
                }
                else
                {
                    possibleRooms.RemoveAt(randomRoom);
                    //Debug.Log("Count: " + possibleRooms.Count);
                    //Debug.Log("Pos: " + randomRoom);
                }
            }
            if (foundRoom)
            {
                int randomDir = Random.Range(0, possibleDir.Count);
            
                Vector2 instPos = new Vector2();

                switch (possibleDir[randomDir]){
                    case 1:
                    instPos = new Vector2(room.x - (gridSpacingOffset/2), room.y + (gridSpacingOffset/2));
                    room2 = new Vector2(room.x, room.y + gridSpacingOffset);
                    room3 = new Vector2(room.x - gridSpacingOffset, room.y);
                    room4 = new Vector2(room.x - gridSpacingOffset, room.y + gridSpacingOffset);
                    break;
                    case 2:
                    instPos = new Vector2(room.x + (gridSpacingOffset/2), room.y + (gridSpacingOffset/2));
                    room2 = new Vector2(room.x, room.y + gridSpacingOffset);
                    room3 = new Vector2(room.x + gridSpacingOffset, room.y);
                    room4 = new Vector2(room.x + gridSpacingOffset, room.y + gridSpacingOffset);
                    break;
                    case 3:
                    instPos = new Vector2(room.x - (gridSpacingOffset/2), room.y - (gridSpacingOffset/2));
                    room2 = new Vector2(room.x - gridSpacingOffset, room.y);
                    room3 = new Vector2(room.x, room.y - gridSpacingOffset);
                    room4 = new Vector2(room.x - gridSpacingOffset, room.y - gridSpacingOffset);
                    break;
                    case 4:
                    instPos = new Vector2(room.x + (gridSpacingOffset/2), room.y - (gridSpacingOffset/2));
                    room2 = new Vector2(room.x, room.y - gridSpacingOffset);
                    room3 = new Vector2(room.x + gridSpacingOffset, room.y);
                    room4 = new Vector2(room.x + gridSpacingOffset, room.y - gridSpacingOffset);
                    break;
                }
                unusedRooms.Remove(room);
                unusedRooms.Remove(room2);
                unusedRooms.Remove(room3);
                unusedRooms.Remove(room4);

                int randomModel = Random.Range(0, bigRoomModels.Count);
                Instantiate(bigRoomModels[randomModel], instPos, Quaternion.identity);
            }
            else Debug.Log("Not enough space for a big room");
        }
    }
    private void Choose1x2Rooms()
    {
        List<Vector2> possibleRooms = AvailableRoomsList(false, 1);

        List<int> possibleDir = new List<int>();
        Vector2 room = new Vector2();
        Vector2 room2 = new Vector2();

        for (int a = 0; a < ammountOfTallRooms; a++)
        {
            bool foundRoom = false;

            while (!foundRoom && possibleRooms.Count > 0){
                int randomRoom = Random.Range(0, possibleRooms.Count);

                List<Vector3> neighbours = CheckNeigbours(possibleRooms, randomRoom, false, unusedRooms, 1);
                List<int> dir = GetNeighboursDirections(neighbours);
                
                if(dir.Contains(1) || dir.Contains(3))
                {
                    if (dir.Contains(1))
                    {
                        foundRoom = true;
                        possibleDir.Add(1);
                        room = possibleRooms[randomRoom];
                    }
                    else
                    {
                        foundRoom = true;
                        possibleDir.Add(3);
                        room = possibleRooms[randomRoom];
                    }
                }
                else
                {
                    possibleRooms.RemoveAt(randomRoom);
                    //Debug.Log("Count: " + possibleRooms.Count);
                    //Debug.Log("Pos: " + randomRoom);
                }
            }

            if (foundRoom)
            {
                int randomDir = Random.Range(0, possibleDir.Count);
                
                Vector2 instPos = new Vector2();

                switch (possibleDir[randomDir]){
                    case 1:
                    instPos = new Vector2(room.x, room.y + (gridSpacingOffset/2));
                    room2 = new Vector2(room.x, room.y + gridSpacingOffset);
                    break;
                    case 3:
                    instPos = new Vector2(room.x, room.y - (gridSpacingOffset/2));
                    room2 = new Vector2(room.x, room.y - gridSpacingOffset);
                    break;
                }

                unusedRooms.Remove(room);
                unusedRooms.Remove(room2);

                int randomModel = Random.Range(0, tallRoomModels.Count);
                Instantiate(tallRoomModels[randomModel], instPos, Quaternion.identity);
            }
            else Debug.Log("Not enough space for a tall room");
        }
    }
    private void Choose1x3Rooms()
    {
        List<Vector2> possibleRooms = AvailableRoomsList(false, 1);

        Vector2 room = new Vector2();

        for (int a = 0; a < ammountOfTallerRooms; a++)
        {
            bool foundRoom = false;

            while (!foundRoom && possibleRooms.Count > 0){
                int randomRoom = Random.Range(0, possibleRooms.Count);

                List<Vector3> neighbours = CheckNeigbours(possibleRooms, randomRoom, false, unusedRooms, 1);
                List<int> dir = GetNeighboursDirections(neighbours);
                
                if (dir.Contains(1) && dir.Contains(3))
                {
                    foundRoom = true;
                    room = possibleRooms[randomRoom];
                }
                else
                {
                    possibleRooms.RemoveAt(randomRoom);
                    //Debug.Log("Count: " + possibleRooms.Count);
                    //Debug.Log("Pos: " + randomRoom);
                }
            }

            if (foundRoom)
            {
                unusedRooms.Remove(room);
                unusedRooms.Remove(new Vector2(room.x, room.y + gridSpacingOffset));
                unusedRooms.Remove(new Vector2(room.x, room.y - gridSpacingOffset));

                int randomModel = Random.Range(0, tallerRoomModels.Count);
                Instantiate(tallerRoomModels[randomModel], room, Quaternion.identity);
            }
            else Debug.Log("Not enough space for a taller room");
        }
    }
    private void Choose2x1Rooms()
    {
        List<Vector2> possibleRooms = AvailableRoomsList(false, 2);

        List<int> possibleDir = new List<int>();
        Vector2 room = new Vector2();
        Vector2 room2 = new Vector2();

        for (int a = 0; a < ammountOfWideRooms; a++)
        {
            bool foundRoom = false;

            while (!foundRoom && possibleRooms.Count > 0){
                int randomRoom = Random.Range(0, possibleRooms.Count);

                List<Vector3> neighbours = CheckNeigbours(possibleRooms, randomRoom, false, unusedRooms, 2);
                List<int> dir = GetNeighboursDirections(neighbours);
                
                if(dir.Contains(2) || dir.Contains(4))
                {
                    if (dir.Contains(2))
                    {
                        foundRoom = true;
                        possibleDir.Add(2);
                        room = possibleRooms[randomRoom];
                    }
                    if (dir.Contains(4))
                    {
                        foundRoom = true;
                        possibleDir.Add(4);
                        room = possibleRooms[randomRoom];
                    }
                }
                else
                {
                    possibleRooms.RemoveAt(randomRoom);
                    //Debug.Log("Count: " + possibleRooms.Count);
                    //Debug.Log("Pos: " + randomRoom);
                }
            }

            if (foundRoom)
            {
                int randomDir = Random.Range(0, possibleDir.Count);

                Vector2 instPos = new Vector2();

                switch (possibleDir[randomDir]){
                    case 2:
                    instPos = new Vector2(room.x - (gridSpacingOffset/2), room.y);
                    room2 = new Vector2(room.x - gridSpacingOffset, room.y);
                    break;
                    case 4:
                    instPos = new Vector2(room.x + (gridSpacingOffset/2), room.y);
                    room2 = new Vector2(room.x + gridSpacingOffset, room.y);
                    break;
                }

                unusedRooms.Remove(room);
                unusedRooms.Remove(room2);

                int randomModel = Random.Range(0, wideRoomModels.Count);
                Instantiate(wideRoomModels[randomModel], instPos, Quaternion.identity);
            }
            else Debug.Log("Not enough space for a wide room");
        }
    }
    private void Choose3x1Rooms()
    {
        List<Vector2> possibleRooms = AvailableRoomsList(false, 2);

        Vector2 room = new Vector2();

        for (int a = 0; a < ammountOfTallerRooms; a++)
        {
            bool foundRoom = false;

            while (!foundRoom && possibleRooms.Count > 0){
                int randomRoom = Random.Range(0, possibleRooms.Count);

                List<Vector3> neighbours = CheckNeigbours(possibleRooms, randomRoom, false, unusedRooms, 2);
                List<int> dir = GetNeighboursDirections(neighbours);
                
                if (dir.Contains(2) && dir.Contains(4))
                {
                    foundRoom = true;
                    room = possibleRooms[randomRoom];
                }
                else
                {
                    possibleRooms.RemoveAt(randomRoom);
                    //Debug.Log("Count: " + possibleRooms.Count);
                    //Debug.Log("Pos: " + randomRoom);
                }
            }

            if (foundRoom)
            {
                unusedRooms.Remove(room);
                unusedRooms.Remove(new Vector2(room.x + gridSpacingOffset, room.y));
                unusedRooms.Remove(new Vector2(room.x - gridSpacingOffset, room.y));

                int randomModel = Random.Range(0, widerRoomModels.Count);
                Instantiate(widerRoomModels[randomModel], room, Quaternion.identity);
            }
            else Debug.Log("Not enough space for a wider room");
        }
    }
    private void ChooseLRooms()
    {
        List<Vector2> possibleRooms = AvailableRoomsList(false, 3);
            
        List<int> possibleDir = new List<int>();
        Vector2 room = new Vector2();
        Vector2 room2 = new Vector2();
        Vector2 room3 = new Vector2();

        for (int a = 0; a < ammountOfLRooms; a++)
        {
            bool foundRoom = false;
            
            while (!foundRoom && possibleRooms.Count > 0){
                int randomRoom = Random.Range(0, possibleRooms.Count);

                List<Vector3> neighbours = CheckNeigbours(possibleRooms, randomRoom, false, unusedRooms, 3);
                List<int> dir = GetNeighboursDirections(neighbours);
                
                /*
                12 - up left
                14 - up right
                23 - down left
                34 - down right
                */
                if(dir.Contains(1) && dir.Contains(2) || dir.Contains(1) && dir.Contains(4) || dir.Contains(2) && dir.Contains(3) || dir.Contains(3) && dir.Contains(4))
                {
                    if (dir.Contains(1) && dir.Contains(2))
                    {
                        foundRoom = true;
                        possibleDir.Add(1);
                        room = possibleRooms[randomRoom];
                    }
                    if (dir.Contains(1) && dir.Contains(4))
                    {
                        foundRoom = true;
                        possibleDir.Add(2);
                        room = possibleRooms[randomRoom];
                    }
                    if (dir.Contains(2) && dir.Contains(3))
                    {
                        foundRoom = true;
                        possibleDir.Add(3);
                        room = possibleRooms[randomRoom];
                    }
                    if (dir.Contains(3) && dir.Contains(4))
                    {
                        foundRoom = true;
                        possibleDir.Add(4);
                        room = possibleRooms[randomRoom];
                    }
                }
                else
                {
                    possibleRooms.RemoveAt(randomRoom);
                    Debug.Log("Count: " + possibleRooms.Count);
                    Debug.Log("Pos: " + randomRoom);
                }
            }

            if (foundRoom)
            {
                int randomDir = Random.Range(0, possibleDir.Count);

                int randomModel;

                switch (possibleDir[randomDir]){
                    case 1:
                    room2 = new Vector2(room.x, room.y + gridSpacingOffset);
                    room3 = new Vector2(room.x - gridSpacingOffset, room.y);

                    unusedRooms.Remove(room);
                    unusedRooms.Remove(room2);
                    unusedRooms.Remove(room3);

                    randomModel = Random.Range(0, bigRoomModels.Count);
                    Instantiate(l1RoomModels[randomModel], room, Quaternion.identity);
                    break;

                    case 2:
                    room2 = new Vector2(room.x, room.y + gridSpacingOffset);
                    room3 = new Vector2(room.x + gridSpacingOffset, room.y);

                    unusedRooms.Remove(room);
                    unusedRooms.Remove(room2);
                    unusedRooms.Remove(room3);

                    randomModel = Random.Range(0, bigRoomModels.Count);
                    Instantiate(l2RoomModels[randomModel], room, Quaternion.identity);
                    break;

                    case 3:
                    room2 = new Vector2(room.x - gridSpacingOffset, room.y);
                    room3 = new Vector2(room.x, room.y - gridSpacingOffset);

                    unusedRooms.Remove(room);
                    unusedRooms.Remove(room2);
                    unusedRooms.Remove(room3);

                    randomModel = Random.Range(0, bigRoomModels.Count);
                    Instantiate(l3RoomModels[randomModel], room, Quaternion.identity);
                    break;

                    case 4:
                    room2 = new Vector2(room.x, room.y - gridSpacingOffset);
                    room3 = new Vector2(room.x + gridSpacingOffset, room.y);

                    unusedRooms.Remove(room);
                    unusedRooms.Remove(room2);
                    unusedRooms.Remove(room3);

                    randomModel = Random.Range(0, bigRoomModels.Count);
                    Instantiate(l4RoomModels[randomModel], room, Quaternion.identity);
                    break;
                }
            }
            else Debug.Log("Not enough space for an L room");   
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