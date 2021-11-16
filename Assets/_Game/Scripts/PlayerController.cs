using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    private PlayerInputActions inputActions;
    [SerializeField] private float speed = 10.0f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
        inputActions.PlayerControls.Attack.performed += OnAttackInput;
    }

    private void Update() {
        Vector2 moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed * Time.deltaTime;
        
    }

    private void OnAttackInput(InputAction.CallbackContext obj) {
        Debug.Log("Attack pressed");
    }
}