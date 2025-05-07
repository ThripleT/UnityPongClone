using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 8f;
    private Rigidbody2D rb;
    private Vector2 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);
        velocity = new Vector2(x, y).normalized * initialSpeed;
        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 bounce = contact.point;
        Debug.Log(velocity);
        Debug.Log(bounce);
        if (-4.8 < bounce.y && bounce.y < 4.8) // its impossible for the ball to hit a paddle at this y coordinate
        {
            velocity.x *= -1f;
        }
        else
        {
            velocity.y *= -1f;
        }
        Debug.Log(velocity);
        velocity *= 1.05f;
        Debug.Log(velocity);
        rb.linearVelocity = velocity;
    }
}
