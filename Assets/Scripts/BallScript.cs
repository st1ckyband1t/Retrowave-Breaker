using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    // Config parameters
    [SerializeField] Paddle paddle1;

    
    //state
    Vector2 paddleToBallVec;


	// Use this for initialization
	void Start () {
        paddleToBallVec = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
	}
}
