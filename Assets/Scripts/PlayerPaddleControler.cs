using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [Tooltip("Set to Vertical1, Vertical2, or any axis name defined in Input Manager")]
    public string movimentAxisName = "Vertical1";

    [Header("Boundary Limits")]
    [SerializeField] private float yLimit = 4.5f;

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if(isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
        }

    }

    void Update()
    {
        float moveInput = Input.GetAxis(movimentAxisName);

        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -yLimit, yLimit);

        transform.position = newPosition;
    }
}