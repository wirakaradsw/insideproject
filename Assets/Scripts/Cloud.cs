using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float targetXStart;
    public float targetXEnd;
    public float speed = 1f;
    Vector3 target;

    void Start()
    {
        target = new Vector3(targetXEnd, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x >= targetXEnd)
        {
            transform.position = new Vector3(targetXStart, transform.position.y, transform.position.z);
        }
    }
}
