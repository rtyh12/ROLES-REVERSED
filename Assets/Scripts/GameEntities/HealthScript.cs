using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum Team {
    hero,
    enemy,
}

public class HealthScript : MonoBehaviour {
    private float _health;
    public float health {
        get { return _health; }
        set {
            _health = value;
            if (_health <= 0) {
                Die();
            }
            _health = Mathf.Min(_health, maxHealth);
            UpdateHealthBar(_health);
        }
    }
    public float _maxHealth;
    public float maxHealth {
        get {
            return team == Team.hero ? SceneMaster.heroMaxHP : _maxHealth;
        }
    }

    public bool isHero;

    public GameObject healthBarPrefab;
    private Image healthBarImage;
    private GameObject healthBarCanvas;

    public Team team;

    private Color healthBarHealthyColor = new Color(255f / 255f, 195f / 255f, 174f / 255f);
    private Color healthBarMidColor = new Color(214f / 255f, 118f / 255f, 118f / 255f);
    private Color healthBarDyingColor = new Color(147f / 255f, 51f / 255f, 94f / 255f);

    public float healthyAbove = 0.8f;
    public float midAbove = 0.3f;

    public void UpdateHealthBar(float health) {
        if (healthBarImage == null) {
            return;
        }
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);

        if (health > maxHealth * healthyAbove) {
            healthBarImage.color = healthBarHealthyColor;
        } else if (health > maxHealth * midAbove) {
            healthBarImage.color = healthBarMidColor;
        } else {
            healthBarImage.color = healthBarDyingColor;
        }

        healthBarCanvas.SetActive(health < maxHealth - 0.01f);
    }

    void Start() {
        healthBarCanvas = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBarCanvas.transform.SetParent(this.transform);
        healthBarImage = healthBarCanvas.transform
                        .GetChild(0).transform
                        .GetChild(0).gameObject
                        .GetComponent<Image>();
        health = maxHealth;
    }

    void Die() {
        var hero = GameObject.Find("Hero");
        var deathEffects = GetComponents<IDeathEffect>();
        foreach (var deathEffect in deathEffects) {
            deathEffect.PerformOn(hero);
        }

        if (team == Team.enemy) {
            SceneMaster.enemyKilledCounter();
            Debug.Log(SceneMaster.killedEnemies);
        } else {
           SceneManager.LoadScene(14);
        }

        Destroy(gameObject);
    }
}
