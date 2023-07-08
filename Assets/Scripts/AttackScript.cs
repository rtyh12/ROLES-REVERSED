using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float baseDamage;
    private BoxCollider2D boxCollider;

    public float attackCooldown;
    private float timeUntilAttack = 0;

    private List<GameObject> collidingObjects = new List<GameObject>();

    public bool attacksPlayer;
    public bool attacksEnemy;

    private HealthScript healthScript;  // team is stored in the health

    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        healthScript = gameObject.GetComponent<HealthScript>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collidingObjects.Add(col.gameObject);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        collidingObjects.Remove(col.gameObject);
    }

    void Update()
    {
        timeUntilAttack -= Time.deltaTime;

        if (collidingObjects.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, collidingObjects.Count);
        GameObject other = collidingObjects[randomIndex];

        Team? thisTeam = this.GetComponent<HealthScript>()?.team;
        Team? otherTeam = other.GetComponent<HealthScript>()?.team;
        if (thisTeam == null || otherTeam == null)
        {
            return;
        }

        if (other.tag == "Damageable"
            && timeUntilAttack <= 0
            && otherTeam != thisTeam)
        {
            timeUntilAttack = attackCooldown;
            Damage(other);
        }
    }

    void Damage(GameObject contactingObject)
    {
        HealthScript healthScript = contactingObject.GetComponent<HealthScript>();
        if (healthScript == null)
        {
            return;
        }

        healthScript.health -= baseDamage;
    }
}
