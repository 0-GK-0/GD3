using System.Collections.Generic;
using UnityEngine;

public class CrumbFollowAttempt : MonoBehaviour
{
    [Header("Enemy Status")]
    public float speed;
    public int damage;
    public float atkCooldown;
    public float currentAtkCooldown;
    public GameObject atk;
    public bool pursuing = false;

    [Header("Enemy Pursuit Values")]
    public float pursuitRange;
    public float atkRange;

    [Header("Other Values")]
    private float distance;
    private Crumbs crumbs;

    [SerializeField] private Rigidbody2D rb;
    Vector2 direction;
    private GameObject[] crumb;

    void Update()
    {
        crumb = GameObject.FindGameObjectsWithTag("Crumbs");
        GameObject mostRecentCrumb = crumb[0];
        //int crumbValue = crumb.crumbs.crumbNumber;
    }
}
