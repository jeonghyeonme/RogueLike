using System.Diagnostics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("���� ���")]
    public GameObject[] enemyPrefabs;

    [Header("�÷��̾�")]
    public Transform playerTransform;

    [Header("���� ����")]
    public float spawnDistance = 5f;
    public bool onlyOnce = false;

    [Header("��ٿ�")]
    public float cooldownTime = 3f;
    private float cooldownTimer = 0f;
    private bool hasSpawned = false;

    void Update()
    {
        if (playerTransform == null || enemyPrefabs.Length == 0)
            return;

        float distance = Vector2.Distance(transform.position, playerTransform.position);
        cooldownTimer += Time.deltaTime;

        UnityEngine.Debug.Log($"[Spawner: {name}] Distance: {distance}");

        if (distance <= spawnDistance && cooldownTimer >= cooldownTime)
        {
            SpawnEnemy();
            cooldownTimer = 0f;

            if (onlyOnce && !hasSpawned)
            {
                hasSpawned = true;
                enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ�� �ݺ� ����
            }
        }
    }

    void SpawnEnemy()
    {
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], transform.position, Quaternion.identity);
        UnityEngine.Debug.Log($"[Spawner: {name}] Spawned {enemy.name}");
    }
}