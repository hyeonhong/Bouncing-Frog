/**
 * Script attached to Canvas object in the Instructions scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour {

	public Button instructionsButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToStartScene()
	{
		SceneManager.LoadScene("Start Screen");
	}
}
