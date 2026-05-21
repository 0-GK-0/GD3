using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseShips : MonoBehaviour
{
    [SerializeField] private int minNumOfShips = 1;
    [SerializeField] private int maxNumOfShips;
    [SerializeField] private int numOfShips;
    [SerializeField] private GameObject shipButton;
    [SerializeField] private List<Ship> ships;
    private List<Ship> possibleShips;
    private List<Ship> chosenShips;
    [SerializeField] private List<Transform> shipPositions;
    private List<Transform> possibleShipPositions;
    

    //Choose which ships to Spawn
    public void RadomShips()
    {
        possibleShips = ships;
        for(int i = 0; i < numOfShips; i++)
        {
            int shipNum = Random.Range(0, ships.Count);

            chosenShips.Add(possibleShips[shipNum]);
            possibleShips.RemoveAt(shipNum);
        }
    }
    //Spawn Ships in terminal
    public void SpawnTerminalShips()
    {
        possibleShipPositions = shipPositions;
        for(int i = 0; i < chosenShips.Count; i++)
        {
            int randomPos = Random.Range(0, possibleShipPositions.Count);

            Instantiate(shipButton, possibleShipPositions[randomPos].position, Quaternion.identity);
            possibleShipPositions.RemoveAt(randomPos);
        }
    }
}
