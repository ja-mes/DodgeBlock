using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text scoreText;
    public ParticleSystem part;
    public Image shieldImage;
    public Transform movePoint1;
    public Transform movePoint2;
    public float lerpSpeed = 20f;
    private float adjustedLerpSpeed;
    public bool isDead = false;
    public float timeBeforeDestruction = 1f;

    bool shieldState = true;
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

    public void ResetShieldInTime(float time)
    {
        Invoke("ResetShield", time);
        Invoke("StartShieldBlink", time - 2);
    }

    private void ResetShield()
    {
        Globals.GM.playerHasShield = false;
    }
    public void ChangeInfoColor(bool enabled)
    {
        if (enabled)
        {
            shieldImage.color = new Color32(255, 69, 0, 33);

            // FREEZE COLOR 
            // shieldImage.color = new Color32(60, 158, 225, 33);
        }
        else
        {
            shieldImage.color = Color.clear;
        }
    }

    public void StartShieldBlink()
    {
        StartCoroutine(BlinkShield());
    }

    IEnumerator BlinkShield()
    {
        bool hasShield = Globals.GM.playerHasShield;

        if (!hasShield)
            ChangeInfoColor(false);

        while (Globals.GM.playerHasShield)
        {
            yield return new WaitForSeconds(0.2f);
            shieldState = !shieldState;
            ChangeInfoColor(shieldState);
        }


        ChangeShieldColor(false);
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

        // must refind GM here
        GameManager GM = GameObject.FindObjectOfType<GameManager>();

        GM.ResetSceneWithTimeout(timeBeforeDestruction);
        GM.score = score;

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
