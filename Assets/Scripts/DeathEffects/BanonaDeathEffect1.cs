using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BanonaDeathEffect : MonoBehaviour, IDeathEffect {
    public float hungerRestoreAmount = 10;
    
    public void PerformOn(GameObject hero) {
        hero.GetComponent<HeroScript>().hunger += hungerRestoreAmount;
    }
}
