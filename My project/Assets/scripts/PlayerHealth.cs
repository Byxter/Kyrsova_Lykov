using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathEffect;
    public DeathScreenManager deathScreenManager;

    public static event System.Action<int, int> OnHealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(DamageAnimation());

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

        if (deathScreenManager != null)
        {
            deathScreenManager.ShowDeathScreen();
        }
        else
        {
            Debug.LogError("DeathScreenManager is not set in the inspector.");
        }
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    private void UpdateHealthBar()
    {
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
}
