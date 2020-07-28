using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 24;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject[] bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;
   

    private GameObject clonePaddle;
    private int CurrentLevel;

      
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) { instance = this; }
            
        else if (instance != this) { Destroy(gameObject); }
            

        Setup();

    }
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab[CurrentLevel], transform.position, Quaternion.identity);
        bricks = FindObjectsOfType<Bricks>().Length;
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            CurrentLevel += 1;

            if (CurrentLevel == bricksPrefab.Length)
            {
                youWon.SetActive(true);
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
            }
            else 
            { 
                Invoke("Setup", resetDelay);
                Destroy(clonePaddle);
                Destroy(FindObjectOfType<Ball>().gameObject);

            }
            
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }
    void Reset()    
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void OnDestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
