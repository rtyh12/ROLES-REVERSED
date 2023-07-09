using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneMaster
{
    public static int levelCounter = 1;

    // HERO
    public static float heroAttackDamageInitial = 10;
    public static float heroMaxHungerInitial = 50;
    public static float heroMaxHPInitial = 100;
    
    public static float heroAttackDamage = heroAttackDamageInitial;
    public static float heroMaxHunger = heroMaxHungerInitial;
    public static float heroMaxHP = heroMaxHPInitial;

    public static float heroXP = 0;
    public static float heroRomance = 0;

    // enemy things
    public static int killedEnemies = 0;
    public static int killedDucks = 0;
    public static int killedBanonas = 0;

    // blah
    public static bool initiateEmailText = false;
    public static bool firstCubicleScene = true;
    public static bool textDone = false;

    public static List<List<string>>  cubicleTexts = new List<List<string>>() {new List<string>() {"New threat spotted at the eastern border!","Some idiot wants to invade HQ and foil our evil plan™!","Coordinate the troops to eliminate the intruder.","1 Attachment."},
        new List<string>() {"Per my last email, there seems to have been a miscommunication.","This matter now has top priority.","Resources are available as necessary, utilize them."},
        new List<string>() {"You have been scheduled for a performance review.","Please demonstrate your ability to contribute to the task at hand and prove your commitment to evil plan™."},
        new List<string>() {"Based on your successful performance review I am adding additional responsibilities to your position.","New troops are coming in but they are missing corporate training and can be impatient and difficult to work with."},
        new List<string>() {"HR has let me know that there will be no additional compensation for these responsibilities.","Nonetheless, we expect you to keep up with your previous duties as well.","Project Kill Hero must be completed."},
        new List<string>() {"The Hero is rapidly approaching HQ.","In order to ensure continuity of evil plans™, we must eliminate them before they reach our gate.","In case of failure, you will be held accountable."},
        new List<string>() {"I’m out of the office preparing evil plans™ and will be back at [Date of Return].","During this period I will have limited access to my email.","Please deal with any problems through hand-to-hand combat."},
        new List<string>() {"As a mandatory team-building exercise I am requesting that all units be sent out in teams of two.","It is important that we all find partners we can really rely on ahead of the evil plan™ launch."},
        new List<string>() {"Just wanted to touch base regarding project Kill Hero, due to increasing urgency I require a status update ASAP!"},
        new List<string>() {"FINAL DEADLINE:","Deliverable due!","Hero quite literally knocking at our door, last chance to avoid disaster and make sure evil plans™ can go ahead as planned.","All units are available and at high alert.","DO NOT DISAPPOINT ME."}
        } ;

    public static List<List<string>> fightTexts = new List<List<string>>() { new List<string>() {"Oh dang, that threat looks pretty cute… *blush*","Kind of a shame to kill someone that good looking…","Maybe I can just scare them away without anyone getting hurt?" },
        new List<string>() {"Oh no!","They are hurt!","They need a doctor!" },
        new List<string>() {"Hmm, it seems like they are getting hungry…" },
        new List<string>() {"Oh it looks like they got stronger!","Aren’t humans adorable?" },
        new List<string>() {"Those dogs sure can’t wait to get into battle."},
        new List<string>() {"They might come here?","It would be nice to meet them in person…","*blushes*" },
        new List<string>() {"Wait, do they think I’m flirting with them???","*blushes*" },
        new List<string>() { "Guess I can choose my own objectives today…" }
    }  ;


    public static List<string> getDialogue()
    {
        SceneMaster.textDone = false;
        initiateEmailText = false;
        List <string> returnedText = new List<string>();
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            for (int i = 0; i < cubicleTexts[levelCounter-1].Count;  i++)
            {
                returnedText.Add(cubicleTexts[levelCounter-1][i]);
            }

        }
        else 
        {
            for (int i = 0; i < fightTexts[levelCounter-1].Count;  i++)
            {
                returnedText.Add(fightTexts[levelCounter-1][i]);
                initiateEmailText = true;
            }
        }

        returnedText.Add("");
        return returnedText;

    }

    public static void loadNextLevel()
    {
        levelCounter++;
        SceneManager.LoadScene(levelCounter);
    }

    public static void loadCubicle()
    {
        
        SceneManager.LoadScene(1);
    }

    public static void loadEnd()
    {
        SceneManager.LoadScene(13);
    }

    public static void enemyKilledCounter()
    {
        killedEnemies++;
    }

    public static void resetEnemyKilledCounter()
    {
        killedEnemies = 0;
    }

}
