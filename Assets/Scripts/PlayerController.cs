using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _minBoundY = -5.5f;
    [SerializeField] private float _maxBoundY = 5.5f;
    [SerializeField] private float _rotateZSpeed = 1f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.AddForce(Vector3.up * GameManager.Instance.GameConfig.PlayerImpulse, ForceMode.Impulse);
        }

        float velocityX = GameManager.Instance.CurrentLevel.MovementSpeed;
        transform.right = Vector3.Lerp(transform.right, new Vector3(velocityX, _rb.velocity.y, _rb.velocity.z), _rotateZSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (transform.position.y < _minBoundY)
        {
            transform.position = new Vector3(transform.position.x, _minBoundY, transform.position.z);
            _rb.velocity = Vector3.zero;
        }

        if (transform.position.y > _maxBoundY)
        {
            transform.position = new Vector3(transform.position.x, _maxBoundY, transform.position.z);
            _rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.RestartLevel();
    }

    private void OnTriggerExit(Collider other)
    {
        UiManager.Instance.Score++;
    }
}
