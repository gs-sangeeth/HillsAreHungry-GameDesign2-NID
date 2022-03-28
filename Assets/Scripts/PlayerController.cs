using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private float input;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move
        input = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(input * speed * Time.deltaTime * 10f, 0));

        // Flip
        if (input > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (input < 0)
        {
            transform.localScale = Vector3.one;
        }

    }
}
