/**
 * Script attached to FrogInStartScreen object in the Start Screen scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogInStartScreen : MonoBehaviour
{

    public Sprite FrogNormal_100;
    public Sprite FrogExpression_100;
    public float rotateSpeed;
    private float spriteTimer;
    private float spriteTimerDelay;
    private float directionTimer;

    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = FrogNormal_100;
        rotateSpeed = -250f;
        spriteTimer = 1f;
        spriteTimerDelay = 3f;
        directionTimer = 6f;

        transform.localScale = new Vector3(0.5f, 0.5f, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {

        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0)
        {
            rotateSpeed *= -1f;
            directionTimer = 6f;
        }

        spriteTimer -= Time.deltaTime;
        if (spriteTimer <= 0)
        {
            if (GetComponent<SpriteRenderer>().sprite == FrogNormal_100)
            {
                GetComponent<SpriteRenderer>().sprite = FrogExpression_100;
                spriteTimer = spriteTimerDelay;
                return;
            }
            if (GetComponent<SpriteRenderer>().sprite == FrogExpression_100)
            {
                GetComponent<SpriteRenderer>().sprite = FrogNormal_100;
                spriteTimer = spriteTimerDelay;
                return;
            }
        }

        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
