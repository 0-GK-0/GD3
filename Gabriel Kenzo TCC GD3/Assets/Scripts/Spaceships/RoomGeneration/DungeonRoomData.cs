using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon/Room Definition")]
public class DungeonRoomData : ScriptableObject
{
    [field: Header("Core")]
    
    [field: SerializeField] public GameObject RoomPrefab {get; private set;}

    [field: SerializeField] public DungeonRoomType RoomType {get; private set;}
    [field: SerializeField] public int weight {get; private set;} = 1;

    [field: Header("Layout")]

    [field: SerializeField] public int roomX {get; private set;} = 1;
    [field: SerializeField] public int roomY {get; private set;} = 1;
    
    [field: SerializeField] public List<DungeonRoomDoor> RoomDoorsList {get; private set;}
}