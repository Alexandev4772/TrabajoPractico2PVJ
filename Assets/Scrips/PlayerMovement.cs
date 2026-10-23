using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;

    [Header("Movimiento")]
    [SerializeField] public float velocidad = 4f;
    [SerializeField] public float jumpForce = 250f;
    [SerializeField] public float gravity = -15f;

    [Header("Chequeo de Suelo (Raycast)")]
    [SerializeField] public float rayDistance = 1.3f;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontalMove, 0f,  verticalMove).normalized;
        body.linearVelocity = new Vector3(movimiento.x * velocidad, body.linearVelocity.y, movimiento.z * velocidad);
        CheckGround();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(new Vector3(0f, jumpForce, 0f));
        }

    }
    void CheckGround()
    {
        Vector3 origin = transform.position;
        isGrounded = Physics.Raycast(origin, Vector3.down, rayDistance, groundLayer);
        Debug.DrawRay(origin, Vector3.down * rayDistance, Color.red);
    }
}
