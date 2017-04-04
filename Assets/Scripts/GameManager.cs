/**
 * Script attached to Board Manager in the Game scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Sprite FrogNormal;
    public Sprite FrogExpression;

    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject upButton;
    public GameObject downButton;

    public Sprite leftButtonTouch;
    public Sprite rightButtonTouch;
    public Sprite upButtonTouch;
    public Sprite downButtonTouch;

    public Sprite leftButtonIdle;
    public Sprite rightButtonIdle;
    public Sprite upButtonIdle;
    public Sprite downButtonIdle;

    public Sprite healthFive;
    public Sprite healthFour;
    public Sprite healthThree;
    public Sprite healthTwo;
    public Sprite healthOne;

    public Text popup;
    public Text countText;
    public Text winText;
    public Text levelText;
    public AudioClip hitSound;
    public AudioClip missSound;
    public AudioClip levelCompleteSound;

    private GameObject healthSprite;
    private int count;
    private int health;
    private bool hitOrMiss;
    private float timer;
    private float delay;
    private float angle;
    private SpriteRenderer sr;
    private bool invalidOrNoKeyPressed;
    public bool isLeftButtonPressed;
    public bool isRightButtonPressed;
    public bool isUpButtonPressed;
    public bool isDownButtonPressed;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Pause(2f));

        healthSprite = GameObject.FindWithTag("Health");
        healthSprite.SetActive(true);

        sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = FrogNormal;

        timer = Random.Range(3f, 5f);
        delay = 0f;

        angle = 0f;
        count = 0;
        health = GameStats.health;  // health at level 1 = 5
        countText.text = "Count: " + count;
        levelText.text = "Level: " + GameStats.levelNumber;
        winText.text = "";
        popup.text = "";
        popup.enabled = false;
        invalidOrNoKeyPressed = false;
        isLeftButtonPressed = false;
        isRightButtonPressed = false;
        isUpButtonPressed = false;
        isDownButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        delay = Random.Range(3f, 5f);

        switch (health)
        {
            case 5:
                healthSprite.GetComponent<SpriteRenderer>().sprite = healthFive;
                break;
            case 4:
                healthSprite.GetComponent<SpriteRenderer>().sprite = healthFour;
                break;
            case 3:
                healthSprite.GetComponent<SpriteRenderer>().sprite = healthThree;
                break;
            case 2:
                healthSprite.GetComponent<SpriteRenderer>().sprite = healthTwo;
                break;
            case 1:
                healthSprite.GetComponent<SpriteRenderer>().sprite = healthOne;
                break;
            case 0:
                healthSprite.GetComponent<SpriteRenderer>().sprite = null;
                break;
        }

        if (sr.sprite == FrogExpression)
        {
            if (timer <= 0)
            {
                if (invalidOrNoKeyPressed)
                {
                    GameStats.tried++;
                    ProcessFailure();
                    StartCoroutine(DisplayMessage(popup, "Try it again!", .8f));
                    invalidOrNoKeyPressed = false;  // reset the value
                }

                sr.sprite = FrogNormal;
                timer = delay;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || isLeftButtonPressed)
                {
                    isLeftButtonPressed = false;
                    angle = player.transform.eulerAngles.z;  // capture the angle
                    if (45 <= angle && angle < 135)
                        hitOrMiss = true;
                    else
                        hitOrMiss = false;
                    processKey(hitOrMiss);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || isRightButtonPressed)
                {
                    isRightButtonPressed = false;
                    angle = player.transform.eulerAngles.z;  // capture the angle
                    if (225 <= angle && angle < 315)
                        hitOrMiss = true;
                    else
                        hitOrMiss = false;

                    processKey(hitOrMiss);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || isUpButtonPressed)
                {
                    isUpButtonPressed = false;
                    angle = player.transform.eulerAngles.z;  // capture the angle
                    if (315 <= angle || angle < 45)
                        hitOrMiss = true;
                    else
                        hitOrMiss = false;
                    processKey(hitOrMiss);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || isDownButtonPressed)
                {
                    isDownButtonPressed = false;
                    angle = player.transform.eulerAngles.z;  // capture the angle
                    if (135 <= angle || angle < 225)
                        hitOrMiss = true;
                    else
                        hitOrMiss = false;

                    processKey(hitOrMiss);
                }
                else
                {
                    invalidOrNoKeyPressed = true;
                }
            }
        }
        else  // sr.sprite == FrogNormal
        {
            if (timer <= 0)
            {
                sr.sprite = FrogExpression;
                timer = 1.5f;  // short period of time window to hit the button
            }
        }
    }

    IEnumerator Pause(float pauseTime)
    {
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }

    IEnumerator DisplayMessage(Text uiText, string message, float delayAfterMessage)
    {
        uiText.text = message;
        uiText.enabled = true;
        yield return new WaitForSeconds(delayAfterMessage);
        uiText.enabled = false;
    }

    void processKey(bool hitOrMiss)
    {
        GameStats.tried++;
        if (hitOrMiss)
        {
            if (count < 2) // if there has been less than 2 success
            {
                PlayHitSound();
                count++;
                countText.text = "Count: " + count.ToString();
                StartCoroutine(DisplayMessage(popup, "Excellent!", .8f));
            }
            else // mission accomplished
            {
                PlayLevelCompleteSound();
                count++;
                countText.text = "Count: " + count.ToString();
                winText.text = "Level Complete!";
                winText.enabled = true;

                // move to next level
                SetNextLevelParameter();
                Invoke("LoadNextLevel", 2f);
            }
        }
        else
        {
            ProcessFailure();            
            StartCoroutine(DisplayMessage(popup, "Try it again!", .8f));
        }

        sr.sprite = FrogNormal;
        timer = delay;
    }

    private void SetNextLevelParameter()
    {
        GameStats.movingSpeed += 2f;
        if (GameStats.rotationSpeed < 0)
            GameStats.rotationSpeed -= 15f;
        else
            GameStats.rotationSpeed += 15f;
        GameStats.success = count;
        GameStats.printScore();
        GameStats.levelNumber++;
        if (GameStats.health > 1)
            GameStats.health--;
    }

    void ProcessFailure()
    {
        health--;
        if (health <= 0)
        {
            // play game over sound here
            winText.text = "Game Over";
            winText.enabled = true;

            // move to results scene
            GameStats.success = count;
            GameStats.printScore();
            GameStats.resetParameters();
            Invoke("LoadResults", 3f);
        }
        else
        {
            PlayMissSound();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 

    void LoadResults()
    {
        SceneManager.LoadScene("Results");
    }

    public void PlayHitSound()
    {
        if(hitSound)
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, 0));
    }

    public void PlayMissSound()
    {
        if (missSound)
            AudioSource.PlayClipAtPoint(missSound, new Vector3(0, 0, 0));
    }

    public void PlayLevelCompleteSound()
    {
        if (levelCompleteSound)
            AudioSource.PlayClipAtPoint(levelCompleteSound, new Vector3(0, 0, 0));
    }
}
