using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HeroScript : MonoBehaviour {
    public float xp;
    public int level {
        get {
            return (int)(xp / 100.0);
        }
    }
    public float hunger;
    public float romance;

    public float hungerDrainPerSecond = 0.01f;

    public float hungerInitial;
    public float romanceInitial;
    public float xpInitial;

    void Start() {
        hunger = hungerInitial;
        romance = romanceInitial;
        xp = xpInitial;
    }

    void Update() {
        hunger -= hungerDrainPerSecond * Time.deltaTime;
        if (hunger <= 0) {

        }
    }
}
