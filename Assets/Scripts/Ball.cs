using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private new Rigidbody2D rigidbody2D;

    bool ballInPlay;
    Vector2 startingPos;

    public float yPush = 50f;
    public float randomFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        startingPos = transform.position;
        ballInPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballInPlay) UpdateBallPosition();
        if (Input.GetMouseButtonDown(0) && !ballInPlay) FreeBall();
    }

    private void UpdateBallPosition()
    {
        transform.position = new Vector2(paddle.GetComponent<Transform>().position.x, transform.position.y);
    }

    private void FreeBall()
    {
        ballInPlay = true;
        rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), yPush);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        if (ballInPlay)
        {
            rigidbody2D.velocity += velocityTweak;
        }
    }

    public void Reset()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.angularVelocity = 0;
        transform.position = startingPos;
        ballInPlay = false;
    }
}
