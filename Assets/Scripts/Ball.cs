using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config params
    [SerializeField] Paddle Paddle1;
    [SerializeField] Vector2 startingShotForce = new Vector2(12f, 15f);

    // State
    [SerializeField] Vector3 paddleToBallVector = new Vector3(0,0.5f,0);
    bool hasStarted = false;

    // Components
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // Stick the ball to the paddle
            transform.position = Paddle1.transform.position + paddleToBallVector;

            // When the left mouse button is clicked the ball is shot up and the game starts
            if(Input.GetMouseButtonDown(0))
            {
                //rb.AddForce(startingShotForce);
                rb.velocity = startingShotForce;
                hasStarted = true;
            }
        }
    }
}
