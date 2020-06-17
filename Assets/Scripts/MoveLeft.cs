using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private float leftBound = -100.0f;
    private float downBound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < downBound)
        {
            Destroy(gameObject);
        }
    }
}
