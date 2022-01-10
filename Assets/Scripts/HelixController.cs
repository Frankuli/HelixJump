using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startRotation;

    public Transform topTransform;
    public Transform goalTransform;

    public GameObject helixLevelPrefabs;

    public List<Stage> allStages = new List<Stage>();

    public float helixDistance;

    private List<GameObject> spawnedLevel = new List<GameObject>();

    private void Awake()
    {
        startRotation = transform.localEulerAngles;

        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
        LoadStage(0);
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
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count-1)];

        if (stage == null)
        {
            Debug.Log("No Stages");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;
        
        FindObjectOfType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;

        transform.localEulerAngles = startRotation;

        foreach (GameObject go in spawnedLevel)
        {
            Destroy(go);
        }

        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count ; i++)
        {
            spawnPosY -= levelDistance;
            GameObject level = Instantiate(helixLevelPrefabs, transform);

            level.transform.localPosition = new Vector3(0, spawnPosY, 0);

            spawnedLevel.Add(level);
        }

    }
}
