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
    [SerializeField] private List<Ship> chosenShips;
    [SerializeField] private List<Transform> shipPositions;
    private List<Transform> possibleShipPositions;
    
    private void Start()
    {
        RamdomShips();
        SpawnTerminalShips();
    }
    
    //Choose which ships to Spawn
    public void RamdomShips()
    {
        possibleShips = ships;
        for(int i = 0; i < numOfShips; i++)
        {
            int shipNum = Random.Range(0, ships.Count);

            chosenShips.Add(possibleShips[shipNum]);
            possibleShips.RemoveAt(shipNum);
        }
        Debug.Log("Ships Chosen");
    }
    //Spawn Ships in terminal
    public void SpawnTerminalShips()
    {
        possibleShipPositions = shipPositions;
        for(int i = 0; i < chosenShips.Count; i++)
        {
            int randomPos = Random.Range(0, possibleShipPositions.Count);

            GameObject obj = Instantiate(shipButton, possibleShipPositions[randomPos].position, Quaternion.identity);
            obj.GetComponent<TerminalButton>().ChangeButton(chosenShips[i]);
            obj.transform.parent = gameObject.transform;

            possibleShipPositions.RemoveAt(randomPos);
        }
        Debug.Log("Ships Placed");
    }
}
