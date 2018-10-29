
using UnityEngine;

public class BallScript : MonoBehaviour {

    // Config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPushVel = 2f;
    [SerializeField] float yPushVel = 15f;
    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBallVec;
    bool hasStarted = false;

    //cached reference
    Rigidbody2D myrigidBody2D;


    // Use this for initialization
    void Start()//used awake here as it is better after instantiation
    {
        paddleToBallVec = transform.position - paddle1.transform.position;
        myrigidBody2D = GetComponent<Rigidbody2D>();
        //Debug.Log("Awake method is running");
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
            myrigidBody2D.velocity = new Vector2(xPushVel, yPushVel);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            myrigidBody2D.velocity += velocityTweak;
        }   
    }
}
