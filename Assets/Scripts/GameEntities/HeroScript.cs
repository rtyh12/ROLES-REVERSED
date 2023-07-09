using UnityEngine;

public class HeroScript : MonoBehaviour {
    private float _xp;
    public float xp {
        set {
            _xp = xp;
            SetLevelStats(_xp);
        }
        get {
            return _xp;
        }
    }
    public int level;
    public float hunger;

    public float hungerDrainPerSecond = 0.01f;
    public float healthDrainWhenHungryPerSecond = 1f;

    public float romanceInitial;

    private HealthScript healthScript;

    void SetLevelStats(float xp) {
        // calculate level
        level = (int)(xp / 10f);

        // apply effects
        SceneMaster.heroAttackDamage = SceneMaster.heroAttackDamageInitial + level * 2;
        SceneMaster.heroMaxHunger = SceneMaster.heroMaxHungerInitial + level * 5;
        SceneMaster.heroMaxHP = SceneMaster.heroMaxHPInitial + level * 10;

        healthScript.health = Mathf.Min(
            healthScript.health + 10,
            SceneMaster.heroMaxHP
        );
        hunger = Mathf.Min(
            hunger + 5,
            SceneMaster.heroMaxHP
        );

        Debug.Log($"Level={level}, AttackDamage={SceneMaster.heroAttackDamage}, heroMaxHunger={SceneMaster.heroMaxHunger}, heroMaxHP={SceneMaster.heroMaxHunger}");
    }

    void Start() {
        healthScript = GetComponent<HealthScript>();
        
        hunger = SceneMaster.heroMaxHunger;
    }

    void Update() {
        hunger -= hungerDrainPerSecond * Time.deltaTime;
        hunger = Mathf.Max(hunger, 0);
        if (hunger <= 0) {
            healthScript.health -= healthDrainWhenHungryPerSecond * Time.deltaTime;
        }
    }
}
