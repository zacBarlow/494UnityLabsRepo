
using UnityEngine;

public class TPMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool playerGrounded;
    private float speed = 12.0f;
    private float jumpScale = 2.0f;
    private float gravityVal = -9.81f;
    [SerializeField] private Transform cam;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public float turnSmoothPeriod = .1f;
    float turnSmoothSpeed;

    private void Update()
    { 

        playerGrounded = controller.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerDirection = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (playerDirection.magnitude > 0.1f)
        {
            float facingAngle = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, facingAngle, ref turnSmoothSpeed, turnSmoothPeriod);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, facingAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && (playerGrounded || playerVelocity.y == 0f))
        {
            playerVelocity.y += Mathf.Sqrt(jumpScale * -3.0f * gravityVal);
        }
        playerVelocity.y += gravityVal * Time.deltaTime;
        controller.Move(playerVelocity*Time.deltaTime);
    }
   
}