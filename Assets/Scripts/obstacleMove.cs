using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get GameManager
        var gamemanager = GameManager.Instance;

        // ignore if over
        if (gamemanager.isGameOver)
        {
            return;
        }

        // Move Obstacle
        float x = gamemanager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        if (transform.position.x <= -gamemanager.ostacleOffsetX)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }

}
