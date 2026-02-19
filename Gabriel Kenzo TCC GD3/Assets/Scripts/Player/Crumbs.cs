using UnityEngine;

public class Crumbs : MonoBehaviour
{
    public int crumbNumber;

    private void Update()
    {
        crumbNumber++;
        if (crumbNumber >= 100) Destroy(gameObject);
    }
}
