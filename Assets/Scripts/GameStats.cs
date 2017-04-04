/**
 * Standalone class that keeps track of stats in the game.
 * This script is not attached to any game object.
 *
 * @author       Hyeon Hong
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static float scaleValue = 0.5f;
    public static int levelNumber = 1;
    public static float movingSpeed = 2f;
    public static float rotationSpeed = 45f;
    public static int tried = 0;
    public static int success = 0;
    public static string results = "";
    public static int health = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void printScore()
    {
            results += "Level     " + levelNumber + ":   " + success + " / " + tried + "\n";
            tried = 0;
            success = 0;
    }

    public static void resetParameters()
    {
        movingSpeed = 2f;
        rotationSpeed = 45f;
        levelNumber = 1;
        health = 5;
    }
}
