/**
 * Script attached to Frog object in the Game scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float directionTimer;

    void Start()
    {
        transform.localScale = new Vector3(GameStats.scaleValue, GameStats.scaleValue, transform.localScale.z);

        transform.position = new Vector3(0, 0, transform.position.z);

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Random.insideUnitCircle.normalized * GameStats.movingSpeed;  // Random direction
        rb2d.freezeRotation = true;

        directionTimer = 6f;
        GameStats.rotationSpeed *= -1f;  // starts with rotating rightward
    }

    void Update()
    {
        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0)
        {
            GameStats.rotationSpeed *= -1f;
            directionTimer = 6f;
        }

        transform.Rotate(0, 0, GameStats.rotationSpeed * Time.deltaTime);

        if (rb2d.velocity.x == 0 || rb2d.velocity.y == 0)
        {
            rb2d.velocity = Random.insideUnitCircle.normalized * GameStats.movingSpeed;
        }
    }

}
