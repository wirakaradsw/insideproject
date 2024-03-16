using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLine : MonoBehaviour
{
    public float scaleY;
    public float minScaleTime = 0.5f;
    public float speed = 100f;
    float targetY = 0;
    Vector2 target;
    bool isMoveUp = false;
    void Start()
    {
        isMoveUp = true;
        SetTarget();
        transform.localScale = target;
    }

    void Update()
    {
        if (isMoveUp)
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, target, speed * Time.deltaTime);
            
            if (transform.localScale.y >= targetY)
            {
                SetMoveUp(false);
            }
        }
        else
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, target, speed * Time.deltaTime);

            if (transform.localScale.y <= targetY)
            {
                SetMoveUp(true);
            }
        }
    }

    private void SetTarget()
    {
        targetY = Random.Range((scaleY * minScaleTime), scaleY);
        target = new Vector2(transform.localScale.x, targetY);
    }

    private void SetMoveUp (bool isUp)
    {
        isMoveUp = isUp;
        SetTarget();
    }
}
