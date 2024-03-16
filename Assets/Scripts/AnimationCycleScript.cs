using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCycleScript : MonoBehaviour
{
    private GameObject[] childObj;
    public float setSpeed = 0.5f;
    private float speed = 0f;

    void Start()
    {
        int totChild = this.gameObject.transform.childCount;
        childObj = new GameObject[totChild];
        for (int i = 0; i < totChild; i++)
        {
            childObj[i] = this.gameObject.transform.GetChild(i).gameObject;
            childObj[i].SetActive(false);
        }
        childObj[0].SetActive(true);
        speed = setSpeed;
    }

    void Update()
    {
        speed = speed - Time.deltaTime;

        if (speed <= 0f)
        {
            if (childObj[childObj.Length-1].activeSelf)
            {
                childObj[childObj.Length-1].SetActive(false);
                childObj[0].SetActive(true);
            }
            else
            {
                for (int i = 0; i < childObj.Length; i++)
                {
                    if (childObj[i].activeSelf)
                    {
                        childObj[i].SetActive(false);
                        childObj[i + 1].SetActive(true);
                        break;
                    }
                }
            }
            speed = setSpeed;
        }
    }
}
