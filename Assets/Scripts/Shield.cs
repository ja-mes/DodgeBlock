using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem ps;
    private Player player;
    private float shieldDuration = 6f;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Globals.GM.playerHasShield = true;

            player.ResetShieldInTime(shieldDuration);
            player.ChangeInfoColor(true);

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
