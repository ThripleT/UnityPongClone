using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 8f;
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
        Debug.Log("Test");
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
        Vector2 bounce = contact.point;
        if (-4.8 < bounce.y && bounce.y < 4.8) // its impossible for the ball to hit a paddle at this y coordinate
        {
            velocity.x *= -1f;
        }
        else
        {
            velocity.y *= -1f;
        }
        velocity *= 1.05f;
        rb.linearVelocity = velocity;
    }
}
