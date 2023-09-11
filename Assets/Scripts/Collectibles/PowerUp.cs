
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public float speed;
    void Start()
    {
       
    }

    void Update()
    {
        // Move the object with normal speed
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= -12.25f)
            Destroy(gameObject);

    }
}

