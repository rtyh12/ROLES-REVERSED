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
    public float healthDrainWhenHungryPerSecond = 1f;

    public float hungerInitial;
    public float romanceInitial;
    public float xpInitial;

    private HealthScript healthScript;

    void Start() {
        healthScript = GetComponent<HealthScript>();
        
        hunger = hungerInitial;
        romance = romanceInitial;
        xp = xpInitial;
    }

    void Update() {
        hunger -= hungerDrainPerSecond * Time.deltaTime;
        hunger = Mathf.Max(hunger, 0);
        if (hunger <= 0) {
            healthScript.health -= healthDrainWhenHungryPerSecond * Time.deltaTime;
        }
    }
}