using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Ledge ledge;

    void Start()
    {
        ledge= GetComponentInParent<Ledge>();
    }

    void LateUpdate()
    {
        if (transform.position.z == 4)
        {
            transform.Translate(0, 0, ledge.blockCount * ledge.blockSize * -1);
        }
    }
}
