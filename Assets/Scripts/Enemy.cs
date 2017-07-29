using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem part;

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

    void InvokeExplosion()
    {
        ParticleSystem newPart = Instantiate(part, transform.position, Quaternion.identity);
        newPart.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Globals.GM.playerHasShield)
            {
                Globals.Player.IncScore(10);
                InvokeExplosion();
                Destroy(this.gameObject);
            }
            else
            {
                Globals.Player.InvokeExplosion();
                Globals.Player.Die();
            }
        }
    }

}
