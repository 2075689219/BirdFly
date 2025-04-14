using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [HideInInspector]
    public GameObject target;
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Destroy the obstacle if it goes out of bounds (left side of the screen)
        if (target != null && transform.position.z < target.transform.position.z - 10f)
        {
            Destroy(gameObject);
        }

    }
}
