using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;   // 前进速度
    //public float horizontalSpeed = 3f;  // 左右速度
    //public float verticalSpeed = 3f;    // 上下速度
    [SerializeField] public float jumpForce = 5f;       // 跳跃力度
    [SerializeField] public float gravity = 9.81f;     // 重力
    public float maxVerticalSpeed = 10f; // 最大垂直速度
    private float verticalVelocity; // 垂直速度
    private bool isGrounded = false; // 是否在地面上


    void Update()
    {
        MoveBird();
        Fly();
    }

    void MoveBird()
    {
        // 前进
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        // 正常下坠
        if (!isGrounded)
        {
            verticalVelocity += -gravity * Time.deltaTime;
            verticalVelocity = Mathf.Clamp(verticalVelocity, -maxVerticalSpeed, float.MaxValue);
            transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
        }
        // 检测是否在地面上（简单的地面检测，实际游戏中可能需要更复杂的碰撞检测）
        isGrounded = transform.position.y <= 0f;

    }

    void Fly()
    {
        // 振翅
        if (!isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpForce;
        }
    }
}
