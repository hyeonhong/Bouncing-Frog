/**
 * Script attached to "Frog In Setting" object in the Settings scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogInSettings : MonoBehaviour {

    public Sprite FrogNormal_100;
    public Sprite FrogExpression_100;
    private float spriteTimer;
    private float spriteTimerDelay;
    private float directionTimer;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = (new Vector3(0, 1, 0)) * GameStats.movingSpeed;  // Vector should be normalized (unit vector)
        rb2d.freezeRotation = true;
        transform.localScale = new Vector3(GameStats.scaleValue, GameStats.scaleValue, transform.localScale.z);

        spriteTimer = 1f;
        spriteTimerDelay = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = rb2d.velocity.normalized * GameStats.movingSpeed;
        transform.localScale = new Vector3(GameStats.scaleValue, GameStats.scaleValue, transform.localScale.z);
        transform.Rotate(0, 0, -1f * GameStats.rotationSpeed * Time.deltaTime);

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
    }
}
