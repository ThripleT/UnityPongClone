using System;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public enum Side { left, right }
    public Side goalSide;

    [Header("UI Test References")]
    public Text leftScoreText;
    public Text rightScoreText;

    private static int leftScore;
    private static int rightScore;

    private void Start()
    {
        UpdateScoreUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (goalSide == Side.left) { rightScore++; }
        if (goalSide == Side.right) { leftScore++; }

        UpdateScoreUI();

        ResetBall(collision.gameObject);
    }

    private void ResetBall(GameObject ball)
    {
        ball.GetComponent<BallController>().StartRound();
    }

    private void UpdateScoreUI()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }
}
