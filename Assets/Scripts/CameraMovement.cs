using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float offsetY = .5f, offsetX=.5f, offsetZ = .5f;
    Movement movement;
    private void Start()
    {
        movement = FindObjectOfType<Movement>();

    }

    void Update()
    {
        transform.position = new Vector3( movement.gameObject.transform.position.x-offsetX, movement.gameObject.transform.position.y-offsetY,  offsetZ);
    }
}
