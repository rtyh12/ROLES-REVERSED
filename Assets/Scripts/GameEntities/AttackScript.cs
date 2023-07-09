using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AttackScript : MonoBehaviour {
    public float baseDamage;
    private BoxCollider2D boxCollider;

    public float attackCooldown;
    private float timeUntilAttack = 0;

    private List<GameObject> collidingObjects = new List<GameObject>();

    private HealthScript healthScript;  // team is stored in the health
    private Animator animator;

    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        healthScript = GetComponent<HealthScript>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        collidingObjects.Add(col.gameObject);
    }

    void OnCollisionExit2D(Collision2D col) {
        collidingObjects.Remove(col.gameObject);
    }

    void FixedUpdate() {
        timeUntilAttack -= Time.deltaTime;

        if (collidingObjects.Count == 0) {
            return;
        }

        int randomIndex = Random.Range(0, collidingObjects.Count);
        GameObject other = collidingObjects[randomIndex];

        Team? myTeam = this.GetComponent<HealthScript>()?.team;
        Team? theirTeam = other.GetComponent<HealthScript>()?.team;
        if (myTeam == null || theirTeam == null) {
            return;
        }

        if (other.tag == "Damageable" && timeUntilAttack <= 0 && myTeam != theirTeam) {
            timeUntilAttack = attackCooldown;

            if (animator != null) {
                animator.SetTrigger("Attack");
            }
            Damage(other);
        }
    }

    void Damage(GameObject contactingObject) {
        HealthScript healthScript = contactingObject.GetComponent<HealthScript>();
        if (healthScript == null) {
            return;
        }

        healthScript.health -= baseDamage;
    }
}
