using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FlowerDeathEffect : MonoBehaviour, DeathEffect {
    public float romanceAmount = 10;
    
    public void PerformOn(GameObject hero) {
        hero.GetComponent<HeroScript>().romance += romanceAmount;
    }
}
