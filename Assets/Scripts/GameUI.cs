/**
 * Script attached to UI object (Canvas) in the Game scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Image pauseButton;
    public Sprite pause;
    public Sprite play;

    private GameObject boardManager;
    private GameManager gmScript;

    // Use this for initialization
    void Start () {
        boardManager = GameObject.Find("Board Manager");
        gmScript = boardManager.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPauseButtonClick()
    {
        if (pauseButton.sprite == pause)
        {
            pauseButton.sprite = play;
            Time.timeScale = 0;
        }
        else
        {
            pauseButton.sprite = pause;
            Time.timeScale = 1;
        }
    }

    public void OnLeftButtonClick()
    {
        gmScript.isLeftButtonPressed = true;
    }

    public void OnRightButtonClick()
    {
        gmScript.isRightButtonPressed = true;
    }

    public void OnUpButtonClick()
    {
        gmScript.isUpButtonPressed = true;
    }

    public void OnDownButtonClick()
    {
        gmScript.isDownButtonPressed = true;
    }
}
