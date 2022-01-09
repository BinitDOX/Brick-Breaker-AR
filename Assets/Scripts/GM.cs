using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 25;
    public float resetDelay = 2f;
    public GameObject gameOver;
    public GameObject gameWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject ball;
    public GameObject deathParti;
    public GameObject life3;
    public GameObject life2;
    public GameObject life1;
    public static GM instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        //Setup();
    }

    public void Setup()
    {
        //clonePaddle.transform.SetParent(transform.parent);
        Instantiate(paddle);
        //cloneBall.transform.SetParent(transform.parent);
        Instantiate(ball);
        //Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void ChkGameOver()
    {
        if(bricks < 1)
        {
            gameWon.SetActive(true);
            Time.timeScale = 0.3f;
            Invoke("Reset", resetDelay);
        }

        if(lives < 1)
        {
            life1.SetActive(false);
            gameOver.SetActive(true);
            //Ball.rb.isKinematic = true;
            //Ball.ballInPlay = false;
            Time.timeScale = 0.3f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Ball.rb.isKinematic = true;
        Ball.ballInPlay = false;
        SceneManager.LoadScene("Brick Breaker");
    }

    public void LoseLife()
    {
        lives--;
        if(lives == 2)
        {
            life2.SetActive(true);
            life3.SetActive(false);
        }
        if(lives == 1)
        {
            life1.SetActive(true);
            life2.SetActive(false);
        }
        Instantiate(deathParti, paddle.transform.position, Quaternion.identity);
        paddle.SetActive(false);
        ball.SetActive(false);
        //Destroy(ball);
        Invoke("SetupPaddle", resetDelay);
        ChkGameOver();
    }

    void SetupPaddle()
    {
        paddle.SetActive(true);
        Ball.rb.isKinematic = true;
        ball.transform.position = new Vector3(0f, 0f, 0f);
        Ball.ballInPlay = false;
        ball.SetActive(true);
        //Instantiate(ball, paddle.transform.position, Quaternion.identity);

    }

    public void DestroyBrick()
    {
        bricks--;
        ChkGameOver();
    }
}
