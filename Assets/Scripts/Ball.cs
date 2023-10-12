using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float maxVelocity = 5;
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;
    public TextMeshProUGUI playerOneTextMeshProUGUI;
    public TextMeshProUGUI playerTwoTextMeshProUGUI;
    public Transform respawnPoint; 
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentVelocity = _rb.velocity.magnitude;

        // Check if the current velocity is greater than the maximum.
        if (currentVelocity > maxVelocity)
        {
            // Calculate the scaled velocity to bring it under the maximum.
            Vector2 scaledVelocity = _rb.velocity.normalized * maxVelocity;

            // Set the Rigidbody2D velocity to the scaled velocity.
            _rb.velocity = scaledVelocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Goal_1") || col.tag.Equals("Goal_2"))
        {
            switch (col.tag)
            {
                case "Goal_1":
                    _playerTwoScore++;
                    playerTwoTextMeshProUGUI.text = _playerTwoScore.ToString();
                    break;
                case "Goal_2":
                    _playerOneScore++;
                    playerOneTextMeshProUGUI.text = _playerOneScore.ToString();
                    break;
            }
            
            _rb.bodyType = RigidbodyType2D.Static;
            transform.position = respawnPoint.position;
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
