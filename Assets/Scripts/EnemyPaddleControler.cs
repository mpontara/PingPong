using UnityEngine;
using UnityEngine.InputSystem; 

public class EnemyPaddleController : MonoBehaviour
{
   private Rigidbody2D rb;
   public float speed = 3f;
   private GameObject ball;
   public Vector2 limits = new Vector2(-4.5f, 4.5f);

   void Start()
   {
     rb = GetComponent<Rigidbody2D>();
     ball = GameObject.Find("Ball");
   }

   void Update()
   {
    if (ball != null)
    {
        float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y);
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }

   }


}