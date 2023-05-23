using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform transformSnake;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    private void Start()
    {
        xOffset = transform.position.x - transformSnake.position.x;
        yOffset = transform.position.y - transformSnake.position.y;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(transformSnake.position.x + xOffset, transformSnake.position.y + yOffset, 0);
    }
}
