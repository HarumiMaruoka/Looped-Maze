using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float _rotateSpeed = 3.0f;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // �}�E�X�̉��ړ��ʂ��擾
        float mouseX = Input.GetAxisRaw("Mouse X");
        // �}�E�X�̉��ړ��ʂɉ�����y������]
        transform.Rotate(0, mouseX * _rotateSpeed, 0);

        // ���͂��擾
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        var rotation = transform.rotation;
        var moveDirection = rotation * new Vector3(horizontal, 0, vertical);
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z).normalized;

        _rb.velocity = new Vector3(moveDirection.x * moveSpeed, _rb.velocity.y, moveDirection.z * moveSpeed);
    }
}
