/**
 * Script attached to Canvas object in the Results scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsController : MonoBehaviour {

    public Text resultsText;
    public Button backButton;

    // Use this for initialization
    void Start () {
        resultsText.text = GameStats.results;
        GameStats.results = "";
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void GoToStartScene()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
