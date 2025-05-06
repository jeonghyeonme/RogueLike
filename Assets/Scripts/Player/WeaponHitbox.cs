using System.Diagnostics;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damage = 1;

    [Header("Collider Reference")]
    public Collider2D hitboxCollider;  // �ݵ�� IsTrigger=true�� Collider ����

    void Awake()
    {
        // �ڵ����� ����ǵ��� ó��
        if (hitboxCollider == null)
            hitboxCollider = GetComponent<Collider2D>();

        // ó������ ��Ȱ��ȭ
        if (hitboxCollider != null)
            hitboxCollider.enabled = false;
    }

    /// <summary>
    /// �ִϸ��̼� �̺�Ʈ���� ȣ�� (�ֵθ��� ���� ����)
    /// </summary>
    public void EnableHitbox()
    {
        if (hitboxCollider != null)
            hitboxCollider.enabled = true;
    }

    /// <summary>
    /// �ִϸ��̼� �̺�Ʈ���� ȣ�� (�ֵθ��� �� ����)
    /// </summary>
    public void DisableHitbox()
    {
        if (hitboxCollider != null)
            hitboxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitboxCollider.enabled) return;

        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                UnityEngine.Debug.Log("������ �������� �־����ϴ�.");
            }
        }
    }
}