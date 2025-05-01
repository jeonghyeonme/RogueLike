using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;               // �÷��̾� ��ġ
    public Transform weaponSpriteTransform;         // ȸ��/��������Ʈ ��� (�ڽ� ������Ʈ)
    public Camera mainCamera;

    [Header("Position Offset")]
    public Vector3 rightOffset = new Vector3(0.5f, 0f, 0f);
    public Vector3 leftOffset = new Vector3(-0.5f, 0f, 0f);

    void LateUpdate()
    {
        if (playerTransform == null || mainCamera == null) return;

        // 1. ���콺�� �÷��̾��� ��ũ�� ��ǥ ��
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(playerTransform.position);

        // 2. ���� ��ġ�� �÷��̾� ���� ������ ���� (����/������)
        if (mouseScreenPos.x < playerScreenPos.x)
        {
            transform.position = playerTransform.position + leftOffset;
        }
        else
        {
            transform.position = playerTransform.position + rightOffset;
        }

        // 3. ���콺 ���� ���
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        Vector3 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 4. ���� ȸ�� ó��
        if (mouseScreenPos.x < playerScreenPos.x)
        {
            weaponSpriteTransform.rotation = Quaternion.Euler(0f, 180f, -angle);
        }
        else
        {
            weaponSpriteTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}