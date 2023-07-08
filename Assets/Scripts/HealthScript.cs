using UnityEngine;
using UnityEngine.UI;

public enum Team {
    hero,
    enemy,
}

public class HealthScript : MonoBehaviour
{
    private float _health;
    public float health
    {
        get { return _health; }
        set
        {
            _health = value;
            UpdateHealthBar(_health);
        }
    }
    public float maxHealth;

    public GameObject healthBarPrefab;
    private Image healthBarImage;
    private GameObject healthBarCanvas;

    public Team team;

    public void UpdateHealthBar(float health)
    {
        if (healthBarImage == null)
        {
            return;
        }
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);
        healthBarCanvas.SetActive(health < maxHealth - 0.01);
    }

    void Start()
    {
        healthBarCanvas = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBarCanvas.transform.SetParent(this.transform);
        healthBarImage = healthBarCanvas.transform
                        .GetChild(0).transform
                        .GetChild(0).gameObject
                        .GetComponent<Image>();
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
