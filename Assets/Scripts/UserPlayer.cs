using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : Player
{
    private void Start()
    {
        moveSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        base.LimitMovement();
    }

    // Makes the platform player uses move verticallly
    public override void MovePlayer()
    {
        float verticalInput = GetVerticalInput();

        transform.Translate(Vector2.up * verticalInput * moveSpeed * Time.deltaTime);
    }

    // Gets vertical input keys from user
    private float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }
}
