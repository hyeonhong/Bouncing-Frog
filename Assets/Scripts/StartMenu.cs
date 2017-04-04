/**
 * Script attached to Menu UI (Canvas) object in the Start Screen scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public FrogInStartScreen frog;
    private Slider calibration;

    // Use this for initialization
    void Start()
    {
        calibration = GameObject.FindWithTag("Calibration").GetComponent<Slider>();
        calibration.value = GameStats.scaleValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToInstructionsScene()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void SliderChanged(float newValue)
    {
        GameStats.scaleValue = newValue;
        frog.transform.localScale = new Vector3(newValue, newValue, frog.transform.localScale.z);
    }

    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ClickExit()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }
}
