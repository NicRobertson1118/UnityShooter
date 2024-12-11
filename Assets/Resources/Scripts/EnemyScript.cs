using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D enemyHitbox;

    private int scoreValue = 1;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public int getScoreValue() {
        return scoreValue;
    }
}
