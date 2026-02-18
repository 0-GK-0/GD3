using UnityEngine;

public class AccessSpellBook : MonoBehaviour
{
    public GameObject Interface;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Interface.SetActive(true);
    }
}
