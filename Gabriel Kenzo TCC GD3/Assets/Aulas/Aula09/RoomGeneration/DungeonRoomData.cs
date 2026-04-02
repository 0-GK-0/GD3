using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon/Room Definition")]
public class DungeonRoomData : ScriptableObject
{
    [Header("Core")]
    
    public GameObject RoomPrefab;

    public DungeonRoomType RoomType;
    public int weight = 1;

    [Header("Layout")]

    public Vector2Int RoomSize;
    
    public List<DungeonRoomDoor> RoomDoorsList;
}