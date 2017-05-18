using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool hasHitScore = false;

    void Start()
    {
    }
    void Update()
    {
        if (transform.position.y < -4.4 && !hasHitScore)
        {
            Globals.Player.IncScore();
            hasHitScore = true;
        }
        else if (transform.position.y < -5.5)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && !Globals.GM.playerHasShield)
        {
            Globals.Player.Die();
            col.gameObject.GetComponent<Player>().InvokeExplosion();
        }
    }

}
