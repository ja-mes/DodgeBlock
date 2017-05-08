using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text scoreText;
    public ParticleSystem part;
    public Transform movePoint1;
    public Transform movePoint2;
    public float lerpSpeed = 20f;
    private float adjustedLerpSpeed;
    public bool isDead = false;
    public float timeBeforeDestruction = 1f;

    Rigidbody2D rb;
    Transform des;
    SpriteRenderer sRenderer;
    int score = 0;


    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        adjustedLerpSpeed = lerpSpeed;
        des = movePoint1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (des == movePoint1)
                des = movePoint2;
            else
                des = movePoint1;
        }


        rb.MovePosition(Vector3.Lerp(transform.position, des.position, lerpSpeed * (1 / Time.timeScale) * Time.deltaTime));
    }

    public void InvokeExplosion()
    {
        ParticleSystem newPart = Instantiate(part, transform.position, Quaternion.identity);
        newPart.Play();
    }

    public void ChangeShieldColor(bool enabled)
    {
        if (enabled)
            sRenderer.color = new Color32(255, 177, 60, 255);
        else
            sRenderer.color = Color.white;
    }

    public void IncScore(int amount = 1)
    {
        if (!isDead)
        {
            score += amount;
            scoreText.text = score.ToString();
        }
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
        
        Globals.GM.ResetSceneWithTimeout(timeBeforeDestruction);
        Globals.GM.score = score;

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
