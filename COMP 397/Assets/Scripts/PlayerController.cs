using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float Speed;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        moveDirection.Normalize();
        moveDirection *= Speed;
    }
}
