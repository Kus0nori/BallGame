using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _enemyStartPosition;
    private Rigidbody _rb;
    [SerializeField] private GameObject enemy;
    private void Start()
    {
        _startPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
        _enemyStartPosition = enemy.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Target"))
        {
            Destroy(other.collider.gameObject);
            SetDefaultPos();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SetDefaultPos();
        }
    }

    private void SetDefaultPos()
    {
        transform.position = _startPosition;
        enemy.transform.position = _enemyStartPosition;
        _rb.velocity = new Vector3(0, 0, 0);
    }
}
