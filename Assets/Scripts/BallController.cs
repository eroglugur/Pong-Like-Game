using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Ball's rigidbody
    private Rigidbody2D ballRigidbody;

    // Accesses to the other scripts
    private SpawnManager spawnManager;
    private ScoreManager scoreManager;

    // Ball movement variables
    private float ballMoveSpeed = 7.5f;
    private float ballMoveRangeX = 10.0f;

    // Sound effects
    public AudioSource bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        spawnManager = FindObjectOfType<SpawnManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        SetSpeed();
        StartBallMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballRigidbody.velocity.magnitude != ballMoveSpeed)
        {
            HoldSpeedSteady();
        }

        if (transform.position.x < -ballMoveRangeX || ballMoveRangeX < transform.position.x)
        {
            RespawnBall();
        }
    }

    // Starts the ball's movement by adding force
    void StartBallMovement()
    {
        ballRigidbody.AddForce(transform.up * ballMoveSpeed, ForceMode2D.Impulse);
    }

    // Prevents the ball speed increase or decrease
    void HoldSpeedSteady()
    {
        ballRigidbody.velocity = ballRigidbody.velocity.normalized * ballMoveSpeed;
    }

    // Destroys the ball, spawns a new one in spawn position
    void RespawnBall()
    {
        Destroy(gameObject);
        spawnManager.StartCoroutine("SpawnBall");
    }

    // Updates the scores according to the triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftTrigger"))
        {
            scoreManager.UpdateOpponentScore();
        }

        if (collision.gameObject.CompareTag("RightTrigger"))
        {
            scoreManager.UpdatePlayerScore();
        }
    }

    // Plays the bounce sound on collision with anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceSound.Play();
    }

    // Sets the ball's speed according to the difficulty selected
    void SetSpeed()
    {
        switch (PlayerPrefs.GetInt("Difficulty"))
        {
            case 0:
                ballMoveSpeed = 8.5f;
                break;
            case 1:
                ballMoveSpeed = 10f;
                break;
            case 2:
                ballMoveSpeed = 12.5f;
                break;
        }
    }
}
