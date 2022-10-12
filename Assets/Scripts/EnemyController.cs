using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    public float Speed { get; set; }

    private void Start()
    {
        Speed = 1f;
    }

    private void FixedUpdate()
    {
        if (ball.transform.position.x > 0 || ball.transform.position.z > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ball.transform.position.x,
                transform.position.y, transform.position.z), Speed*Time.deltaTime);
        }
    }
}
