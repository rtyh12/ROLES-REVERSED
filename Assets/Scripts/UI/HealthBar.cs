using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image healthBarImage;
    public HealthScript healthScript;

    public void UpdateHealthBar() {
        healthBarImage.fillAmount = Mathf.Clamp(healthScript.health / healthScript.maxHealth, 0, 1f);
    }
}
