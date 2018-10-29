using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    //config params
    [SerializeField] int lives = 3;
    [SerializeField] GameObject ball;

    BallScript respawnBall;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        respawnBall = FindObjectOfType<BallScript>();
        if (collision.gameObject.tag == "Ball")
        {
            
            if (lives > 0)
            {
                --lives;
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
}
