using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    // Config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPushVel = 2f;
    [SerializeField] float yPushVel = 15f;
    //state
    Vector2 paddleToBallVec;
    bool hasStarted = false;


    // Use this for initialization
    void Start ()
    {
        paddleToBallVec = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }    
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPushVel, yPushVel);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }   
    }
}
