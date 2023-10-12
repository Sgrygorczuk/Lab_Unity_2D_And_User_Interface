using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool isPlayerOne;
    public float speed = 5;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * (speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * (speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * (speed * Time.deltaTime);
                transform.localScale = new Vector3(-1,1,1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * (speed * Time.deltaTime);
                transform.localScale = new Vector3(1,1,1);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * (speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * (speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * (speed * Time.deltaTime);
                transform.localScale = new Vector3(-1,1,1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * (speed * Time.deltaTime);
                transform.localScale = new Vector3(1,1,1);
            }
        }
        
        float currentVelocity = _rb.velocity.magnitude;

        // Check if the current velocity is greater than the maximum.
        if (currentVelocity > 0)
        {
            // Calculate the scaled velocity to bring it under the maximum.
            Vector2 scaledVelocity = _rb.velocity.normalized * 0;

            // Set the Rigidbody2D velocity to the scaled velocity.
            _rb.velocity = scaledVelocity;
        }
    }
}
