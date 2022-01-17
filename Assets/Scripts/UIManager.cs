using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text currentScoreText;
    public Text bestScoreText;

    public Slider slider;
    public Text actualLevel;
    public Text nextLevel;
    public Transform topTrensform;
    public Transform goalTrensform;
    public Transform ball;

    private void Update()
    {
        currentScoreText.text = "Score: " + GameManager.singleton.currentScore;
        bestScoreText.text ="Best: " + GameManager.singleton.bestScore;

        ChangeSlider();
    }

    public void ChangeSlider()
    {
        actualLevel.text = "" + (GameManager.singleton.currentLevel+1);
        nextLevel.text = "" + (GameManager.singleton.currentLevel+2);

        float totalDistance = topTrensform.position.y - goalTrensform.position.y;

        float distanceLeft = totalDistance - (ball.position.y - goalTrensform.position.y);

        float value = (distanceLeft / totalDistance);

        slider.value = Mathf.Lerp(slider.value, value, 5);
    }


}
