using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string axis = "Vertical";

    private void Update()
    {
        float move = Input.GetAxis(axis) * speed * Time.deltaTime;
        transform.Translate(0, move, 0);
        // Clamp Y
        float clampedY = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, clampedY, 0);
    }
}
