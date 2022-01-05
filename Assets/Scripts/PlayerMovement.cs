using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 30f;
    public float gravity = -19.8f;
    Vector3 velocity;
    public float jumphieght = 2f;
    public Joystick joystick;
    public Transform transform;
    public LayerMask groundmask;
    public float groundDistance = 0.3f;
    private ControlFreak2.InputRig.Touch touch;
    public static PlayerMovement movement;
    bool Grounded=true;
    float camerasenstivity = 100f;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        movement = this;
        ControlFreak2.CFCursor.visible = true;
        velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(-8.426389f, -1.82f, 7.790407f);
    }

    // Update is called once per frame
    void Update()
    {

        //float x = joystick.Horizontal;
        //float y = joystick.Vertical;
        float x = ControlFreak2.CF2Input.GetAxis("Horizontal");
        float y = ControlFreak2.CF2Input.GetAxis("Vertical");
        // Vector3 motion = new Vector3(x,0,y);
        Vector3 motion = transform.right * x + transform.forward * y;
        controller.Move(motion * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
   
      
  
    public void Jump()
    {
        Debug.Log("called");
        if (controller.isGrounded)
        {
         
            velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
          
        }
    }
}
