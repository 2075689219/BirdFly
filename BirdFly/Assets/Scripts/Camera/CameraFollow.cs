using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 鸟的位置
    public Vector3 offset;    // 偏移量

    public float smoothSpeed = 0.75f;  // 跟随平滑度，因为用了vector3.Lerp，所以值越小，跟随越平滑，但是也越慢，并且范围是0-1

    void LateUpdate()
    {
        if (target == null) return;

        // 计算目标位置
        Vector3 desiredPosition = target.position + offset;

        // 平滑移动（让镜头不会死跟着，太死板）
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

    }
}
