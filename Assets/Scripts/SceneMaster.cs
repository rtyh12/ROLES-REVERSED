using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneMaster
{
    public static int levelCounter = 0;


    public static bool initiateEmailText = false;
    public static bool firstCubicleScene = true;
    public static bool textDone = false;

    public static List<string>  texts = new List<string>() {"New threat spotted at the eastern border! Some idiot wants to invade HQ and foil our evil plan™! Coordinate the troops to eliminate the intruder. 1 Attachment.",
        "Per my last email, there seems to have been a miscommunication. This matter now has top priority. Resources are available as necessary, utilize them.",
        "You have been scheduled for a performance review. Please demonstrate your ability to contribute to the task at hand and prove your commitment to evil plan™."};

    public static void loadNextLevel()
    {
        levelCounter++;
        SceneManager.LoadScene(levelCounter+1);
    }

    public static void loadCubicle()
    {
        SceneManager.LoadScene(1);
    }



}
