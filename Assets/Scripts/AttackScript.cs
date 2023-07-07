using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float baseDamage;
    public BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag != "Damageable")
        {
            return;
        }

        HealthScript healthScript = col.gameObject.GetComponent<HealthScript>();
        if (healthScript == null)
        {
            return;
        }

        healthScript.health -= baseDamage;
        Debug.Log(healthScript.health);
    }
}
