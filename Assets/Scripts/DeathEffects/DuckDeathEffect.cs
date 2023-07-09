using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DuckDeathEffect : MonoBehaviour, IDeathEffect {
    public float hungerDropped = 10;
    
    public void PerformOn(GameObject hero) {
        hero.GetComponent<HeroScript>().hunger += hungerDropped;
        SceneMaster.killedDucks++;
    }
}
