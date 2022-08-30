using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    public float smoothSpeed;

    private void Start()
    {
        transform.position = ball.position + new Vector3(4, 2, 4);  // oyun baþladýðýn kamerayý topun karþýsýna koyar. rotation ayarý manuel.
        offset = transform.position - ball.position;
    }

    private void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + ball.position, smoothSpeed);
        transform.position = newPos;
    }

}
