using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startPosition;

    public Transform topTransform;
    public Transform goalTransform;

    public GameObject helixLevelPrefabs;

    public List<Stage> allStages = new List<Stage>();

    public float helixDistance;

    private List<GameObject> spawnedLevel = new List<GameObject>();

    private void Awake()
    {
        startPosition = transform.localEulerAngles;

        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
       // LoadStage(0);
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

    public void LoadStage(int stageNumber)
    {

    }
}
