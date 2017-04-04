/**
 * Script attached to ParameterUI (Canvas) object in the Settings scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParameterUI : MonoBehaviour {

    public Text rotationSpeedText;
    public Text movingSpeedText;
    public Text frogSizeText;

    public Sprite healthFive;
    public Sprite healthFour;
    public Sprite healthThree;
    public Sprite healthTwo;
    public Sprite healthOne;

    private Slider rotationSpeedSlider;
    private Slider movingSpeedSlider;
    private Slider frogSizeSlider;
    private Slider healthSlider;
    private GameObject healthObject;

    // Use this for initialization
    void Start ()
    {
        rotationSpeedSlider = GameObject.FindWithTag("RotationSpeed-Slider").GetComponent<Slider>();
        rotationSpeedSlider.value = GameStats.rotationSpeed;

        movingSpeedSlider = GameObject.FindWithTag("MovingSpeed-Slider").GetComponent<Slider>();
        movingSpeedSlider.value = GameStats.movingSpeed;

        frogSizeSlider = GameObject.FindWithTag("Size-Slider").GetComponent<Slider>();
        frogSizeSlider.value = GameStats.scaleValue;

        healthSlider = GameObject.FindWithTag("Health-Slider").GetComponent<Slider>();
        healthSlider.value = GameStats.health;

        healthObject = GameObject.FindWithTag("Health Settings");


        rotationSpeedText.text = (Mathf.Abs(GameStats.rotationSpeed)).ToString() + "  \u00B0 / sec";
        movingSpeedText.text = GameStats.movingSpeed.ToString() + "  m / sec";
        frogSizeText.text = (GameStats.scaleValue * 100.0f).ToString() + " %";
    }
	
	// Update is called once per frame
	void Update () {
        rotationSpeedText.text = (Mathf.Abs(GameStats.rotationSpeed)).ToString() + "  \u00B0 / sec";
        movingSpeedText.text = GameStats.movingSpeed.ToString() + "  m / sec";
        frogSizeText.text = (GameStats.scaleValue * 100.0f).ToString() + " %";
        getHealth();
    }

    public void RotationSpeedChanged(float newValue)
    {
        GameStats.rotationSpeed = (int) newValue;
    }

    public void MovingSpeedChanged(float newValue)
    {
        GameStats.movingSpeed = Mathf.Round(newValue * 10f) / 10f;
    }

    public void FrogSizeChanged(float newValue)
    {
        GameStats.scaleValue = Mathf.Round(newValue * 100f) / 100f;
    }

    public void HealthChanged(float newValue)
    {
        GameStats.health = (int) newValue;
    }

    public void getHealth()
    {
        switch (GameStats.health)
        {
            case 5:
                healthObject.GetComponent<SpriteRenderer>().sprite = healthFive;
                break;
            case 4:
                healthObject.GetComponent<SpriteRenderer>().sprite = healthFour;
                break;
            case 3:
                healthObject.GetComponent<SpriteRenderer>().sprite = healthThree;
                break;
            case 2:
                healthObject.GetComponent<SpriteRenderer>().sprite = healthTwo;
                break;
            case 1:
                healthObject.GetComponent<SpriteRenderer>().sprite = healthOne;
                break;
            case 0:
                healthObject.GetComponent<SpriteRenderer>().sprite = null;
                break;
        }
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
