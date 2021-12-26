using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The range of player's vertical movements
    protected float moveRangeY = 4.0f;

    // Player's speed
    protected float moveSpeed;

    // Keeps the player in the vertical movement range
    public virtual void LimitMovement()
    {
        // Keeps the in the screen if tries to go below the minimum vertical move limit,
        if (transform.position.y < -moveRangeY)
        {
            transform.position = new Vector2(transform.position.x, -moveRangeY);

        }

        // Keeps the in the screen if tries to go above the maximum vertical move limit,
        if (transform.position.y > moveRangeY)
        {
            transform.position = new Vector2(transform.position.x, moveRangeY);
        }

    }

    // Will make the player move vertically
    public virtual void MovePlayer() { }
}
