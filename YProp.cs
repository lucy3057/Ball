using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YProp : MonoBehaviour
{
    public float StartTime;
    public float minY, maxY;

    [Range(1, 100)]
    public float moveSpeed;
    private int sign = -1;

    private float time = 0;

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= StartTime)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime * sign, 0);

            if (transform.position.y <= minY ||
                transform.position.y >= maxY)
            {
                sign *= -1;
            }

        }
    }
}