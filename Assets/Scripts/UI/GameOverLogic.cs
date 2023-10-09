using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{

    public void Retry() {
        SceneMaster.loadNextLevel();
    }
    public void QuitGame() {
        Application.Quit();
    }
}
