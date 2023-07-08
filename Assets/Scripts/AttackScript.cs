using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float baseDamage;
    public BoxCollider2D boxCollider;

    public float attackCooldown;
    private float timeUntilAttack = 0;

    private List<GameObject> collidingObjects = new List<GameObject>();

    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collidingObjects.Add(col.gameObject);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        collidingObjects.Remove(col.gameObject);
    }

    void Update() {
        timeUntilAttack -= Time.deltaTime;
        
        if (collidingObjects.Count == 0) {
            return;
        }

        int randomIndex = Random.Range(0, collidingObjects.Count);
        GameObject toDamage = collidingObjects[randomIndex];

        if (toDamage.tag == "Damageable" && timeUntilAttack <= 0) {
            timeUntilAttack = attackCooldown;
            Damage(toDamage);
        }
    }

    void Damage(GameObject contactingObject) {
        HealthScript healthScript = contactingObject.GetComponent<HealthScript>();
        if (healthScript == null)
        {
            return;
        }

        healthScript.health -= baseDamage;
    }
}
