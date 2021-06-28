using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float movePower;
    //private float time = 0;

    Rigidbody rigid;

    private void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigid.AddForce(new Vector3(0, 0, movePower), ForceMode.Impulse);
        if (rigid.position.y < -5)
        {
            Destroy(this);
        }
    }
}
