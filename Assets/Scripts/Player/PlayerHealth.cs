using System.Diagnostics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UnityEngine.Debug.Log($"[Player] �ǰ�! ���� ü��: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        UnityEngine.Debug.Log("[Player] ���!");
        // ����: ��� �ִϸ��̼� / ����� ó��
    }
}