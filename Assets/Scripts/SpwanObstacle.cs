using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanObstacle : MonoBehaviour
{

    private float coolDown = 0f;

    // Update is called once per frame
    void Update()
    {


        // Get GameManager
        var gamemanager = GameManager.Instance;

        // ignore if over
        if (gamemanager.isGameOver)
        {
            return;
        }
        // Update CoolDown
        coolDown -= Time.deltaTime;
        if (coolDown <= 0f)
        {
            coolDown = gamemanager.obstacleInterval;

            // Spwan ostacle
            int prefabIndex = Random.Range(0, gamemanager.obstaclePrefabs.Count);
            GameObject prefab = gamemanager.obstaclePrefabs[prefabIndex];
            float x = gamemanager.ostacleOffsetX;
            float y = Random.Range(gamemanager.obstacleOffsetY.x, gamemanager.obstacleOffsetY.y);
            float z = 0f;
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
