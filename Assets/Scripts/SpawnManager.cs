using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;
    private float ballSpawnRange = 4.0f;
    private float ballSpawnRotation;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBall");
    }

    // Spawns the ball randomly in limited spawn and rotation 
    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(0.75f);
        Instantiate(ball, GenerateRandomBallSpawnPosY(), GenerateRandomBallSpawnRotation());
    }

    // Returns a spawn position in the spawn range
    Vector2 GenerateRandomBallSpawnPosY()
    {
        return new Vector2(0, Random.Range(-ballSpawnRange, ballSpawnRange));
    }

    // Returns one of the rotation angles (-45, 45, 135, -135) randomly
    Quaternion GenerateRandomBallSpawnRotation()
    {
        // Throws a random number between 0 and 4
        int randomNumber = Random.Range(0, 4);

        // Assigns one of the rotation angles according to the random number
        if (randomNumber == 0)
        {
            ballSpawnRotation = 45.0f;
        }
        else if (randomNumber == 1)
        {
            ballSpawnRotation = -45.0f;
        }
        else if (randomNumber == 2)
        {
            ballSpawnRotation = 135.0f;
        }
        else
        {
            ballSpawnRotation = -135.0f;
        }

        return Quaternion.Euler(0, 0, ballSpawnRotation); ;
    }

}
