using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public ParticleSystem ps;
    public float timeScale = 0.5f;
    public float resetTime = 3;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Time.timeScale = timeScale;

            // Must disable these here because ga cannot be deleted or resetTimeScale will never be run
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

            ParticleSystem newPt = Instantiate(ps, transform.position, Quaternion.identity);
            newPt.Play();

            Invoke("resetTimeScale", resetTime * (1 - timeScale));


            Globals.GM.playerHasFreeze = true;

            Globals.InfoColor.ResetInfoColorInTime(resetTime);
            Globals.InfoColor.ChangeInfoColor("freeze");
        }
    }
    void resetTimeScale()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }

}
