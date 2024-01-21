using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector2 moveDirection;
    [Header("Movements")]
    [SerializeField] float Speed;
    [SerializeField] float Gravity = -30.0f;
    [SerializeField] float JumpHeight = 3.0f;
    [SerializeField] Vector3 Velocity;
    [Header("Ground Detection")]
    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundRadius = 0.5f;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundRadius, GroundMask);
        if (IsGrounded && Velocity.y < 0.0f)
        {
            Velocity.y = -2.0f;

        }
        Vector3 movement = new Vector3(moveDirection.x, 0.0f, moveDirection.y) * Time.fixedDeltaTime;
        controller.Move(movement);
        Velocity.y += Gravity * Time.fixedDeltaTime;
        controller.Move(Velocity * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * Gravity);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        moveDirection.Normalize();
        moveDirection *= Speed;
    }
}
