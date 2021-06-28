using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZProp : MonoBehaviour
{
    public float StartTime;
    public float minZ, maxZ;

    [Range(1, 100)]
    public float moveSpeed;
    private int sign = -1;

    private void Update()
    {
        if (Time.time >= StartTime)
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * sign);

            if (transform.position.z <= minZ ||
                transform.position.z >= maxZ)
            {
                sign *= -1;
            }

        }
    }
}