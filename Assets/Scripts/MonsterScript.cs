using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public GameObject player;
    public float step;

    void FixedUpdate()
    {
        transform.position -= (transform.position - player.transform.position).normalized * step;
    }
}
