using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneMaster
{
    public static int levelCounter = 0;

    // HERO
    // set initial values for these 3 in HeroScript.SetLevelStats
    public static float heroAttackDamageInitial = 10;
    public static float heroMaxHungerInitial = 50;
    public static float heroMaxHPInitial = 10;
    
    public static float heroAttackDamage;
    public static float heroMaxHunger;
    public static float heroMaxHP;

    public static float heroXP = 0;
    public static float heroRomance = 0;


    // blah
    public static bool initiateEmailText = false;
    public static bool firstCubicleScene = true;
    public static bool textDone = false;

    public static List<string>  texts = new List<string>() {"New threat spotted at the eastern border! Some idiot wants to invade HQ and foil our evil plan�! Coordinate the troops to eliminate the intruder. 1 Attachment.",
        "Per my last email, there seems to have been a miscommunication. This matter now has top priority. Resources are available as necessary, utilize them.",
        "You have been scheduled for a performance review. Please demonstrate your ability to contribute to the task at hand and prove your commitment to evil plan�.",
        "Based on your successful performance review I am adding additional responsibilities to your position. New troops are coming in but they are missing corporate training and can be impatient and difficult to work with.",
        "HR has let me know that there will be no additional compensation for these responsibilities. Nonetheless, we expect you to keep up with your previous duties as well. Project Kill Hero must be completed. ",
        "The Hero is rapidly approaching HQ. In order to ensure continuity of evil plans�, we must eliminate them before they reach our gate. In case of failure, you will be held accountable.",
        "I�m out of the office preparing evil plans� and will be back at [Date of Return]. During this period I will have limited access to my email. Please deal with any problems through hand-to-hand combat.",
        "As a mandatory team-building exercise I am requesting that all units be sent out in teams of two. It is important that we all find partners we can really rely on ahead of the evil plan� launch.",
        "Just wanted to touch base regarding project Kill Hero, due to increasing urgency I require a status update ASAP!",
        "FINAL DEADLINE: Deliverable due! Hero quite literally knocking at our door, last chance to avoid disaster and make sure evil plans� can go ahead as planned. All units are available and at high alert. DO NOT DISAPPOINT ME.",
        };

    public static void loadNextLevel()
    {
        levelCounter++;
        SceneManager.LoadScene(levelCounter+1);
    }

    public static void loadCubicle()
    {
        SceneManager.LoadScene(1);
    }

    public static void loadGameOver()
    {

    }

    public static void loadEnd()
    {

    }



}
