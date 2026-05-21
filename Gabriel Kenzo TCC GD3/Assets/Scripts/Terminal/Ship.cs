using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Ships/New Ship")]
public class Ship : ScriptableObject
{
    public enum ShipLevel
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
    }

    [field: Header("Ship Characteristics")]
    [field: SerializeField] public string shipName {get; private set;}
    [field: SerializeField] public string shipDescription {get; private set;}
    [field: SerializeField] public ShipLevel shipLevel {get; private set;}
    [field: SerializeField] public int gridX {get; private set;}
    [field: SerializeField] public int gridY {get; private set;}
    [field: SerializeField] public int bigRooms {get; private set;}
    [field: SerializeField] public int treasureRooms {get; private set;}
    [field: SerializeField] public int puzzleRooms {get; private set;}
    [field: SerializeField] public int lRooms {get; private set;}
    [field: SerializeField] public int longRooms {get; private set;} //1x2
    [field: SerializeField] public int reallyLongRooms {get; private set;} //1x3
    [field: SerializeField] public int wideRooms {get; private set;} //2x1
    [field: SerializeField] public int reallyWideRooms {get; private set;} //3x1
    [field: SerializeField] public int armoryRooms {get; private set;}

    [field: Header("Possible Rooms")]
    [field: SerializeField] public List<DungeonRoomData> possibleBaseRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleBigRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> posibleTreasureRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possiblePuzzleRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleLRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleLongRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleReallyLongRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleWideRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleReallyWideRooms {get; private set;}
    [field: SerializeField] public List<DungeonRoomData> possibleArmoryRooms {get; private set;}

    [field: Header("UI")]
    [field: SerializeField] public Sprite shipIcon {get; private set;}
}
