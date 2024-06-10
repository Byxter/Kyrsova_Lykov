using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2.5f;
    public float attackRange = 1.5f;
    private bool facingRight = true;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found");
        }
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player != null)
        {
            // Двигаем врага к позиции игрока, замораживая по оси Y
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newpos);

            // Определяем направление движения и разворачиваем врага
            if ((facingRight && player.position.x < rb.position.x) || (!facingRight && player.position.x > rb.position.x))
            {
                Flip();
            }

            if(Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("attak");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attak");
    }

    void Flip()
    {
        // Меняем направление, в которое смотрит враг
        facingRight = !facingRight;

        // Получаем локальные координаты масштаба
        Vector3 localScale = rb.transform.localScale;

        // Меняем знак по оси X для отражения спрайта
        localScale.x *= -1;

        // Применяем новый масштаб
        rb.transform.localScale = localScale;
    }
}
