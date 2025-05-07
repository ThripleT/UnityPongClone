using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 8f;
    public float paddleStrenght = 8f;
    private Rigidbody2D rb;
    private Vector2 velocity;

    [Header("UI Test References")]
    public Text countdownText;

    private void Start()
    {
        StartCoroutine(StartRound());
    }

    public IEnumerator StartRound()
    {
        velocity = Vector2.zero;

        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.transform.position = Vector2.zero;

        // countdown
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        countdownText.text = "GO";

        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);
        velocity = new Vector2(x, y).normalized * initialSpeed;
        rb.linearVelocity = velocity;

        yield return new WaitForSeconds(1f);
        countdownText.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        GameObject gameObject = collision.gameObject;
        if (gameObject.GetComponent<PaddleController>() != null)
        {
            Rigidbody2D paddle = gameObject.GetComponent<Rigidbody2D>();
            float collisionY =  rb.position.y - paddle.position.y;

            velocity.y = collisionY * paddleStrenght;
            velocity.x *= -1f;
        }
        else
        {
            velocity.y *= -1f;
        }
        velocity.x *= 1.05f;
        rb.linearVelocity = velocity;
    }
}
