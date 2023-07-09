using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MonsterScript : MonoBehaviour {
    private GameObject hero;
    public float speed;

    void Start() {
        hero = GameObject.Find("Hero");
    }

    void FixedUpdate() {
        transform.position -= (transform.position - hero.transform.position).normalized * speed * 0.01f;
    }
}
