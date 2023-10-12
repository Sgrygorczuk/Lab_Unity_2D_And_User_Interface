using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private bool _movingUp;
    public float speed = 3; 
    

    // Update is called once per frame
    void Update()
    {
        if (_movingUp)
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
        else
        {
            transform.position += Vector3.down * (speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _movingUp = !_movingUp;
    }
}
