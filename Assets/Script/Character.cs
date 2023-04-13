using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHp = 1000;
    public float currentHp = 1000;
    public float upgradeHp = 1.1f;
    private bool hit;
    private float timer;
    [SerializeField] PlayerHpBar hpBar;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                timer = 0;
                hit = false;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (!hit)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                GetComponent<CharGameOver>().GameOver();
            }
            hpBar.SetState(currentHp, maxHp);
            animator.SetTrigger("Hit");
            hit = true;
        }
        
    }
    public void Heal(int amount)
    {
        currentHp += amount;
        hpBar.SetState(currentHp, maxHp);
    }

    public void AddHealth()
    {
        maxHp = maxHp * upgradeHp;
        currentHp *= upgradeHp;
    }
}
