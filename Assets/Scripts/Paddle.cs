using System;
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
    [SerializeField] float resetTime = 5;
    [SerializeField] float paddleXScaleAddition = 0.5f;


    bool broadPaddle = false;


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

    private void BroadPaddlePowerup()
    {
        broadPaddle = true;
        transform.localScale += new Vector3(paddleXScaleAddition, 0, 0);
        StartCoroutine("waitTime");
    }

    private void ResetPaddleSize()
    {
        transform.localScale += new Vector3(-0.5f, 0, 0);
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(resetTime);
        if(broadPaddle == true)
        {
            transform.localScale += new Vector3(-paddleXScaleAddition, 0, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PowerUP")
        {
            //Debug.Log("Paddle collided with" + collision.gameObject.name);
            AudioSource.PlayClipAtPoint(powerUpSound, Camera.main.transform.position, volume);
            Destroy(collision.gameObject);
            BroadPaddlePowerup();
        }
    }
}
