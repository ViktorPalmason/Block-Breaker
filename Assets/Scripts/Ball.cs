using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config params
    [SerializeField] Paddle Paddle1;
    [SerializeField] Vector2 startingShotForce = new Vector2(0f, 10f);
    [SerializeField] AudioClip[] ballSounds;
    // This is used in collision to help prevent the ball getting stuck.
    [SerializeField] float randomVelTweakFactor = 0.2f; 

    // State
    [SerializeField] Vector3 paddleToBallVector = new Vector3(0,0.5f,0);
    [SerializeField] bool hasStarted = false;

    // Components
    Rigidbody2D myRigidBody2D;
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
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
                myRigidBody2D.velocity = startingShotForce;
                hasStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float xTweak = Random.Range(0f, randomVelTweakFactor);
        float yTweak = Random.Range(0f, randomVelTweakFactor);
        Vector2 velocityTweak = new Vector2(xTweak, yTweak);
        if (hasStarted == true)
        {
            myRigidBody2D.velocity += velocityTweak;
            if (myAudioSource != null)
            {
                AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
            }
        }
    }
}
