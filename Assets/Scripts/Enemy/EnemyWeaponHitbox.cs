using UnityEngine;

public class EnemyWeaponHitbox : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damage = 1;

    [Header("Collider Reference")]
    public Collider2D hitboxCollider;

    [Header("Target Layer")]
    public LayerMask targetLayer;  // ��: Player�� ����

    void Awake()
    {
        if (hitboxCollider == null)
            hitboxCollider = GetComponent<Collider2D>();

        if (hitboxCollider != null)
            hitboxCollider.enabled = false;
    }

    public void EnableHitbox()
    {
        if (hitboxCollider != null)
            hitboxCollider.enabled = true;
    }

    public void DisableHitbox()
    {
        if (hitboxCollider != null)
            hitboxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitboxCollider.enabled) return;

        // LayerMask�� Ÿ�� ����
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            // IDamageable ó��
            if (other.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(damage);
                UnityEngine.Debug.Log("Player just get DAMAGED.");
            }

            // DamageFeedback�� �ִٸ� �˹�/������
            if (other.TryGetComponent(out DamageFeedback feedback))
            {
                feedback.TriggerFeedback(transform.position); // ���� ��ġ ���� �˹� ����
            }
        }
    }
}
