using UnityEngine;

public class UpgradeGrid : MonoBehaviour
{
    [Header("Grid")]
    public int gridX = 9;
    public int gridY = 8;

    public float cellSize = 100;
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject gridCell;

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        for (int i = 0; i < gridX*gridY; i++)
        {
            Instantiate(gridCell, gridParent);
        }
    }

    //Snap
    public void SnapPlace()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
}
