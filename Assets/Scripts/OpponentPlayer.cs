using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentPlayer : Player
{
    // To access the ball's movement
    public BallController ballController;

    private void Start()
    {
        SetSpeed();
    }

    void Update()
    {
        MovePlayer();
        base.LimitMovement();
    }

    // Moves the player according to its speed and ball's movement
    public override void MovePlayer()
    {
        ballController = FindObjectOfType<BallController>();

        // Finds the direction to go according to the ball's position
        Vector2 direction = new Vector2(0, ballController.transform.position.y - transform.position.y).normalized;

        // Moves the player if ball is close
        if (ballIsClose())
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);

        }
    }

    // Sets the player's speed according to the difficulty selected
    void SetSpeed()
    {
        switch (PlayerPrefs.GetInt("Difficulty"))
        {
            case 0:
                moveSpeed = 5f;
                break;
            case 1:
                moveSpeed = 6.25f;
                break;
            case 2:
                moveSpeed = 9f;
                break;
        }
    }

    // Checks if ball is on the right side of the screen
    bool ballIsClose()
    {
        if (ballController.transform.position.x >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
