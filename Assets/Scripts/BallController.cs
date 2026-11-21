using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    public GameManager gameManager;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public float speedUp = 1.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = startingVelocity;
        currentVelocity = rb.linearVelocity;
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            currentVelocity = rb.linearVelocity;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflected = Vector2.Reflect(currentVelocity, normal);
            rb.linearVelocity = reflected;
            currentVelocity = reflected;
        }
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 reflected = new Vector2(-currentVelocity.x, currentVelocity.y);
            rb.linearVelocity = reflected;
            currentVelocity = reflected;
            rb.linearVelocity *= speedUp;
        }
        else if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
    }
}