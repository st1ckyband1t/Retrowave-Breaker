using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config parameters
    [SerializeField] float screenWidthInWorldUnits = 16f;
    [SerializeField] float minX = 1.54f;
    [SerializeField] float maxX = 14.45f;


    //cached references
    GameSession theGameSession;
    BallScript theBall;

    // Use this for initialization
	void Start () {
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
}
