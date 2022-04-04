using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_rotate : MonoBehaviour
{
    float z = 10;
    
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * z);
    }
}
