using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody _rb;

    void Start()
    {
        GameSystem.Instance.OnGameCleared += OnCleared;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        GameSystem.Instance.OnGameCleared -= OnCleared;
    }

    private void Move()
    {
        // “ü—Í‚ðŽæ“¾
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        var rotation = Camera.main.transform.rotation;
        var moveDirection = rotation * new Vector3(horizontal, 0, vertical);
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z).normalized;

        _rb.velocity = new Vector3(moveDirection.x * moveSpeed, _rb.velocity.y, moveDirection.z * moveSpeed);
    }

    private void OnCleared()
    {
        Destroy(_rb);
        Destroy(this);
    }
}
