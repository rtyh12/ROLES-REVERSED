using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public bool objectiveReached = false;
    private int fightLevel;

    public GameObject hero;
    public StateManager stateManager;
    public Canvas gameOverScreen;
    private HealthScript healthScript;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = hero.GetComponent<HealthScript>();
        stateManager = GetComponent<StateManager>();
        fightLevel = SceneMaster.levelCounter;
        gameOverScreen = GetComponent<Canvas>();
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    /*
        pause game function, activates a canvas for the game over play
        reload scene
        public canvas; <-- so you can just drag the canvas object in the inspector on this to reference it
        if herohealth == 0{
        canvas.SetActive(True);
        some gamepause function that comes from unity should exist
    */
    public void loadGameOver(){

        if ((healthScript.health <= 0)) {
            //gameOverScreen.gameObject.SetActive(true);
            PauseGame();
        }

    }


    // Update is called once per frame
    // Checks if objective is reached for each fight 
    void Update()
    {   

        
        Debug.Log(objectiveReached);
        loadGameOver();
        switch(fightLevel){

            case 0: 
                // hero kill 1 unit
                if (SceneMaster.killedEnemies >= 1){
                    objectiveReached = true;
                    SceneMaster.resetEnemyKilledCounter();
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;

            case 1:
                // hero kill 10 units
                if (SceneMaster.killedEnemies >= 10){
                    objectiveReached = true;
                    SceneMaster.resetEnemyKilledCounter();
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;

            case 2:
                // hero kill 5 support troops and kill 20 units in total
                // support troops = banona
                if (SceneMaster.killedBanonas >= 5){
                    objectiveReached = true;
                    SceneMaster.killedBanonas = 0;
                    SceneMaster.loadCubicle();
                    SceneMaster.resetEnemyKilledCounter();
                } else {
                    objectiveReached = false;
                }
                break;

            case 3:
                // hero close to death (1/4 health)
                //Debug.Log("third level objective");

                float maxHealth = SceneMaster.heroMaxHP;
                float currentHealth = healthScript.health;
                if ((float)(currentHealth/maxHealth) <= 0.25){
                    objectiveReached = true;
                    SceneMaster.loadCubicle();
                    SceneMaster.resetEnemyKilledCounter();
                } else {
                    objectiveReached = false;
                }
                break;
            
            case 4:
                // hero kill 20 units
                if (SceneMaster.killedEnemies >= 20){
                    objectiveReached = true;
                    SceneMaster.resetEnemyKilledCounter();
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;
            
            case 5:
                // hero kill 20 units, no units impatience
                if (SceneMaster.killedEnemies >= 20){
                    objectiveReached = true;
                    SceneMaster.resetEnemyKilledCounter();
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;
            
            case 6:
                // hero kill 20 units
                if (SceneMaster.killedEnemies >= 20){
                    objectiveReached = true;
                    SceneMaster.resetEnemyKilledCounter();
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;
            
            case 7:
                // hero romance reach 30
                if (SceneMaster.heroRomance == 30){
                    objectiveReached = true;
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;
                
            case 8:
                // kill 30 and romance reach 60
                if (SceneMaster.killedEnemies >= 30 && SceneMaster.heroRomance == 60){
                    objectiveReached = true;
                    SceneMaster.resetEnemyKilledCounter();
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;
            
            case 9:
                //  hero kill 3 ducks
                if (SceneMaster.killedDucks >= 3){
                    objectiveReached = true;
                    SceneMaster.killedDucks = 0;
                    SceneMaster.loadCubicle();
                } else {
                    objectiveReached = false;
                }
                break;
            
            case 10:
                // hero kill 50 
                if (SceneMaster.heroRomance == 50){
                    objectiveReached = true;
                    SceneMaster.loadEnd();
                } else {
                    objectiveReached = false;
                }
                break;
        
            
            default:
                objectiveReached = false;
                break;

        }
    }
}
