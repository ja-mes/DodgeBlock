using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem ps;
    public float shieldDuration = 6f;
    private Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Globals.GM.playerHasShield = true;
            Globals.InfoColor.shieldResetTime += shieldDuration;
            Globals.InfoColor.ChangeInfoColor();

            InvokeExplosion();
            Destroy(this.gameObject);
        }

    }

    void InvokeExplosion()
    {
        ParticleSystem newPart = Instantiate(ps, transform.position, Quaternion.identity);
        newPart.Play();
    }
}
