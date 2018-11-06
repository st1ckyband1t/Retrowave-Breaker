//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config parameters
    [SerializeField] float screenWidthInWorldUnits = 16f;
    [SerializeField] float minX = 1.54f;
    [SerializeField] float maxX = 14.45f;
    [SerializeField] AudioClip powerUpSound;
    [SerializeField] float volume = 0.5f;
    [SerializeField] float resetTime = 5f;
    [SerializeField] float paddleXScaleAddition = 0.5f;
    [SerializeField] float gameSpeedSlowValue = 0.75f;
    [SerializeField] float gameSpeedFastValue = 1.5f;
    
    //powerup state values
    bool broadPaddle = false;
    bool narrowPaddle = false;
    bool slowmo = false;
    bool fastmo = false;

    //cached references
    GameSession theGameSession;
    BallScript theBall;

    // Use this for initialization
	void Awake () {
        
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<BallScript>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
	}

    private void BroadPaddlePowerup()
    {
        broadPaddle = true;
        transform.localScale += new Vector3(paddleXScaleAddition, 0, 0);
        StartCoroutine(waitTime());
    }

    private void NarrowPaddlePowerUp()
    {
        narrowPaddle = true;
        transform.localScale += new Vector3(-paddleXScaleAddition, 0, 0);
        StartCoroutine(waitTime());
    }

    private void SlowGameSpeedPowerUp()
    {
        slowmo = true;
        theGameSession.gameSpeed = gameSpeedSlowValue;
        StartCoroutine(waitTime());
    }

    private void FastGameSpeedPowerUp()
    {
        fastmo = true;
        theGameSession.gameSpeed = gameSpeedFastValue;
        StartCoroutine(waitTime());
    }

    IEnumerator waitTime()
    {
        //Debug.Log("enum called");
        yield return new WaitForSeconds(resetTime);
        //Debug.Log("waittime over");
        if (broadPaddle == true)
        {
            //Debug.Log("Enumerator is working");
            transform.localScale += new Vector3(-paddleXScaleAddition, 0, 0);
            broadPaddle = false;
        }
        else if(narrowPaddle == true)
        {
            transform.localScale += new Vector3(paddleXScaleAddition, 0, 0);
            narrowPaddle = false;
        }
        else if(slowmo == true)
        {
            theGameSession.gameSpeed = 1f;
            slowmo = false;
        }
        else if(fastmo == true)
        {
            theGameSession.gameSpeed = 1f;
        }

    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInWorldUnits; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PowerUP")
        {
            //Debug.Log("Paddle collided with" + collision.gameObject.name);
            AudioSource.PlayClipAtPoint(powerUpSound, Camera.main.transform.position, volume);
            TriggerPowerUp();
            Destroy(collision.gameObject);

        }
    }

    private void TriggerPowerUp()
    {
        int rand = Random.Range(1, 5);

        int powerup = rand;

        switch(powerup)
        {
            case 1:
                BroadPaddlePowerup();
                break;

            case 2:
                NarrowPaddlePowerUp();
                break;

            case 3:
                SlowGameSpeedPowerUp();
                break;

            case 4:
                FastGameSpeedPowerUp();
                break;
        }

    }
}
