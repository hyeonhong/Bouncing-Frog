/**
 * Script attached to SoundController object in the Start Screen scene
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenSound : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
