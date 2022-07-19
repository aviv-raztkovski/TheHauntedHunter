using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);
    }
}
