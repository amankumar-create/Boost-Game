using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] bool rotate;

    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, .15f, 0);
             
        }
    }
}
