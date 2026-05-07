using UnityEngine;

public class DieInXSecs : MonoBehaviour
{
    [SerializeField] private float timer = 2f;

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else Destroy(gameObject);
    }
}
