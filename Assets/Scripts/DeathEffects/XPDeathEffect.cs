using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class XPDeathEffect : MonoBehaviour, IDeathEffect {
    public float xpDropped = 25;
    
    public void PerformOn(GameObject hero) {
        Debug.Log($"a. {SceneMaster.heroXP}");
        SceneMaster.heroXP += xpDropped;
        Debug.Log($"b. {SceneMaster.heroXP}");
        hero.GetComponent<HeroScript>().xp = SceneMaster.heroXP;
    }
}
