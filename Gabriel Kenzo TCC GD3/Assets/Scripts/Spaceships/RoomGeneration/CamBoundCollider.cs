using UnityEngine;

public class CamBoundCollider : MonoBehaviour
{
    [SerializeField] private GameObject colliderObj;
    private BoxCollider2D camBoundary;

    private void Start()
    {
        camBoundary = colliderObj.GetComponent<BoxCollider2D>();
    }

    public void CreateBoundary(int gridX, int gridY, float gridSpacingOffset)
    {
        Vector2 colliderCenter = new Vector2((float)gridX / 2 * gridSpacingOffset - 8, (float)gridY /2 * gridSpacingOffset - 8);
        Vector2 colliderSize = new Vector2(gridX *  gridSpacingOffset, gridY * gridSpacingOffset);

        camBoundary.offset = colliderCenter;
        camBoundary.size = colliderSize;
    }
}