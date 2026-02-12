using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public float speed;

    [Header("Bools")]
    public bool canMove = true;

    [Header("References")]
    [SerializeField] private PHp pHp;

    private void Update(){
        //Is Dead
        if(pHp.isDead) canMove = false;

        //Move
        if(canMove) Move();
    }

    private void Move(){

    }
}
