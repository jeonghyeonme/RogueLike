using System.Diagnostics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("���� ���")]
    public GameObject[] enemyPrefabs;       // ��ȯ�� �� ������ ���

    [Header("�÷��̾� ����")]
    public Transform playerTransform;       // �Ÿ� üũ ���: �÷��̾�

    [Header("���� ����")]
    public float spawnDistance = 5f;        // �÷��̾ �� �Ÿ� �̳��� ���� ����
    public bool onlyOnce = true;            // �� ���� ������ ������ ����

    private bool hasSpawned = false;        // �ߺ� ���� ���� �÷���

    void Update()
    {
        if (playerTransform == null || enemyPrefabs.Length == 0)
            return;

        float distance = Vector2.Distance(transform.position, playerTransform.position);
        UnityEngine.Debug.Log($"[Spawner] Player distance: {distance}");

        if (distance <= spawnDistance && (!onlyOnce || !hasSpawned))
        {
            SpawnEnemy();
            hasSpawned = true;
        }
    }

    void SpawnEnemy()
    {
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], transform.position, Quaternion.identity);
        UnityEngine.Debug.Log($"[Spawned] {enemy.name} at {transform.position}");
    }
}