using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [Range(0f, 1f)] [SerializeField] private float distanceFromPlayer = 0.5f;

    [SerializeField] private GameObject camFocus;
    [SerializeField] private float camMoveSpeed = 0.95f;

    private void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        Vector2 camPos = new Vector2 (mouseScreenPos.x - playerTransform.position.x, mouseScreenPos.y - playerTransform.position.y) * distanceFromPlayer;

        //camFocus.transform.position = Vector3.Lerp(camFocus.transform.position, mouseScreenPos, camMoveSpeed);
        camFocus.transform.position = camPos + new Vector2(playerTransform.position.x, playerTransform.position.y + 0.5f);
    }
}
