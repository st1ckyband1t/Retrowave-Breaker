using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config parameters

    [SerializeField] float screenWidthInWorldUnits = 16f;
    [SerializeField] float minX = 1.54f;
    [SerializeField] float maxX = 14.45f;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInWorldUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
	}
}
