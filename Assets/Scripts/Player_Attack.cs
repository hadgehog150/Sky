using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Transform attackPosition;
    public LayerMask enemy;
    public float attackRadius;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRadius, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SendMessage("Attacked");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRadius);
    }
}
