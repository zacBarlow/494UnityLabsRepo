using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Transform cam;
    

    

    public float turnSmoothPeriod = .1f;
    float turnSmoothSpeed;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerDirection = new Vector3(horizontal, 0f, vertical).normalized;
        if (playerDirection.magnitude >= 0.1f)
        {
            float facingAngle = Mathf.Atan2(playerDirection.x, playerDirection.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, facingAngle, ref turnSmoothSpeed, turnSmoothPeriod);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, facingAngle, 0f) * Vector3.forward;
            MovePlayer(moveDir.normalized);
        }


    }

    private void MovePlayer(Vector3 moveDirection)
    {
        Vector3 moveVec = transform.TransformDirection(moveDirection.normalized) * Speed;
        player.velocity = new Vector3(moveVec.x, player.velocity.y, moveVec.z);
        if (Input.GetKeyDown(KeyCode.Space) && player.velocity.y==0)
        {
            player.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

}
