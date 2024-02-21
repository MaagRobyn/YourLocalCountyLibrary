using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundMask;
    public Transform foot;
    public float velocityMultiplier;

    private CharacterController controller;
    private Vector3 movement;
    private float GROUND_DISTANCE = 0.1f;
    private float horizontal;
    private float vertical;
    private float altitude;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        altitude = CheckIfFalling() ? altitude - 9.87f / 50f : 0;
        //Debug.Log(altitude);
        Move(horizontal, vertical, altitude);
    }

    protected void Move(float horizontal, float vertical, float altitude)
    {
        movement = transform.right * horizontal + transform.forward * vertical + transform.up * altitude;
        //Debug.Log($"{horizontal}, {vertical}");
        
        controller.Move(movement * velocityMultiplier);
    }

    protected bool CheckIfFalling()
    {
        return !Physics.CheckSphere(foot.position, GROUND_DISTANCE, groundMask);
    }
}
