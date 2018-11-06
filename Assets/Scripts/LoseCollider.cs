using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseCollider : MonoBehaviour {

    //config params
    [SerializeField] public int lives = 3;
    [SerializeField] GameObject ball;  
    [SerializeField] TextMeshProUGUI livesText;

    BallScript respawnBall;

    public void Start()
    {
        ShowLives();
    }

	public void OnTriggerEnter2D(Collider2D collision)
    {
        respawnBall = FindObjectOfType<BallScript>();
        if (collision.gameObject.tag == "Ball")
        {
            
            if (lives > 0)
            {
                --lives;
                ShowLives();
                respawnBall.hasStarted = false;
                if (lives == 0)
                {
                    GameOver();
                }
            }
        }
    }

    private void GameOver()
    {
        
        {
            SceneManager.LoadScene("GameOver Menu");
        }
    }


    public void ShowLives()
    {
        livesText.text = lives.ToString();
    }

}
