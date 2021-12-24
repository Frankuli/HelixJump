using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localEulerAngles;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPosicion = Input.mousePosition;

            if (lastTapPosition == Vector2.zero)
            {
                lastTapPosition = currentTapPosicion;
            }

            float distace = lastTapPosition.x - currentTapPosicion.x;
            lastTapPosition = currentTapPosicion;

            transform.Rotate(Vector3.up * distace);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPosition = Vector2.zero;
        }
    }
}
