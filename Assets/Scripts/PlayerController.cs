using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidBody;
    public float jumpPower = 0.2f;

    public float jumpInterval = 0.5f;

    private float jumpCoolDown = 0;



    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Get GameManager
        var gamemanager = GameManager.Instance;


        // Update CoolDown
        jumpCoolDown -= Time.deltaTime;
        bool isGameActive = gamemanager.IsGameActive();
        bool canJump = jumpCoolDown <= 0 && isGameActive;


        // Jump!
        if (canJump)
        {
            bool jumpInput = Input.GetKeyDown(KeyCode.Space); // Button Jump
            if (jumpInput)
            {
                Jump();

            }
        }
        // Rotation
        float angle = Mathf.Lerp(-45, 45, Mathf.InverseLerp(-2, 2, thisRigidBody.velocity.y));
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Toggle gravity
        thisRigidBody.useGravity = isGameActive;

    }
    void OnTriggerEnter(Collider other)
    {
        CustomCollisionEnter(other.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        CustomCollisionEnter(other.gameObject);
    }

    private void CustomCollisionEnter(GameObject other)
    {
        bool isPoint = other.CompareTag("Point");
        if (isPoint)
        {
            // Score
            GameManager.Instance.score++;
            GameManager.Instance.canvasManager.ModifyScore(GameManager.Instance.score);

        }
        else
        {
            // Game Over :(
            GameManager.Instance.EndGame();

        }
    }

    void Jump()
    {
        //Jump
        jumpCoolDown = jumpInterval;
        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);


    }
}
