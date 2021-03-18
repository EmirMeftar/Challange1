using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerControllerX : MonoBehaviour
{
    public float forwardspeed = 100.0f, rightLeftSpeed = 50.0f, hoverSpeed = 15.0f;
    public float forwardAcceleration = 5.0f, rightLeftAcceleration = 5.0f, hoverAcceleration = 5.0f;
    
    public float xrange = 20;
    
    public float verticalInput;
    public float horizontalInput;
    public float hoverInput;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        verticalInput = Mathf.Lerp(verticalInput, Input.GetAxis("Vertical") * forwardspeed, forwardAcceleration * Time.deltaTime);
        horizontalInput = Mathf.Lerp(horizontalInput,Input.GetAxis("Horizontal") * rightLeftSpeed, rightLeftAcceleration * Time.deltaTime);
        hoverInput = Mathf.Lerp(hoverInput ,Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);
        if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }
        
       

        // tilt the plane up/down based on space/left ctrl keys
        transform.position += transform.up * hoverInput * Time.deltaTime;
    }
}
