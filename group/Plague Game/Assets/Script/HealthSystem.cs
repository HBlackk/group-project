using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int currentHealth;
    private int maxHealth;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public float GetHealthPercent()
    {
        return (float) currentHealth / maxHealth;
    }

    public void Dammage(int damAmount)
    {
        currentHealth -= damAmount;
        if (currentHealth < 0) currentHealth = 0;
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}
//https://www.youtube.com/watch?v=0T5ei9jN63M