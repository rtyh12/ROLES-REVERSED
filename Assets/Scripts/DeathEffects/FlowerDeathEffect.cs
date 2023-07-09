using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FlowerDeathEffect : MonoBehaviour, IDeathEffect {
    public float romanceDropped = 10;
    
    public void PerformOn(GameObject hero) {
        SceneMaster.heroRomance += romanceDropped;
    }
}
