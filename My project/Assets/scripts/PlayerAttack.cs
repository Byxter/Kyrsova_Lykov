using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attakPoint;
    public float attakRange = 0.5f;
    public LayerMask Enemy;

    public int atkDamage = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void Attack()
    {
        anim.SetTrigger("attak");

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attakPoint.position, attakRange, Enemy);

        foreach(Collider2D Enemy in hitenemies)
        {
            Enemy.GetComponent<Enemy>().takedamage(atkDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attakPoint == null)
            return;
        Gizmos.DrawWireSphere(attakPoint.position, attakRange);
    }
}
