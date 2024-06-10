using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxH = 1;
    int currenh;
    public Rigidbody2D rb;

    void Start()
    {
        currenh = maxH;
        rb = GetComponent<Rigidbody2D>();
    }
    public void takedamage(int damage)
    {
        currenh -= damage;

       anim.SetTrigger("hurt");

        if(currenh <= 0)
        {
            EnemyCount.enemies += 1;
            Die();
        }
    }

    void Die()
    {
       anim.SetBool("die", true);

       this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
