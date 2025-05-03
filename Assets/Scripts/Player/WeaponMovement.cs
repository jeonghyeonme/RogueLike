using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;               // �÷��̾� ��ġ
    public Transform weaponSpriteTransform;         // ���� Sprite�� ���� �ڽ� ������Ʈ
    public Camera mainCamera;

    [Header("Offset")]
    public Vector3 rightOffset = new Vector3(0.5f, -0.2f, 0f); // ������ �� ��ġ
    public Vector3 leftOffset = new Vector3(-0.5f, -0.2f, 0f); // ���� �� ��ġ

    [Header("Rotation")]
    public float rotationSmoothSpeed = 15f;         // ȸ�� �ε巯�� ����

    void LateUpdate()
    {
        if (playerTransform == null || mainCamera == null || weaponSpriteTransform == null)
            return;

        // ���콺 �� �÷��̾��� ��ũ�� ��ǥ
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(playerTransform.position);
        bool isMouseLeft = mouseScreenPos.x < playerScreenPos.x;

        // ���� ��ġ ������Ʈ
        Vector3 offset = isMouseLeft ? leftOffset : rightOffset;
        transform.position = playerTransform.position + offset;

        // ���콺 ���� ���
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;

        Vector3 direction = (mouseWorldPos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������ ��� ȸ�� ���� ����
        if (isMouseLeft)
        {
            angle += 180f;
        }

        // ȸ�� ����
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        weaponSpriteTransform.rotation = Quaternion.Lerp(
            weaponSpriteTransform.rotation,
            targetRotation,
            rotationSmoothSpeed * Time.deltaTime
        );

        // �¿� flip (scale.x ����)
        Vector3 scale = weaponSpriteTransform.localScale;
        scale.x = isMouseLeft ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        weaponSpriteTransform.localScale = scale;
    }
}