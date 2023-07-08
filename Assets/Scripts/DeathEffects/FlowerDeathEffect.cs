using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FlowerDeathEffect : MonoBehaviour, IDeathEffect {
    public float romanceAmount = 10;
    
    public void PerformOn(GameObject hero) {
        hero.GetComponent<HeroScript>().romance += romanceAmount;
    }
}
