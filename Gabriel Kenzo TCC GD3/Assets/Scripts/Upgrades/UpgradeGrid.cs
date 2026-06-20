using UnityEngine;

public class UpgradeGrid : MonoBehaviour
{
    public int gridX = 9;
    public int gridY = 8;

    public float cellSize = 100;

    //Snap
    public void SnapPlace()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
}
