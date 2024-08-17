using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 20;
    public float rotateSpeed = 20;
    public float verticalInput;
    public float horizontalInput;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.left, Time.deltaTime * rotateSpeed * verticalInput);
        transform.Rotate(Vector3.back, Time.deltaTime * rotateSpeed * horizontalInput);
        //transform.Rotate(Vector3.left, Time.deltaTime * -5); 
    }
}
