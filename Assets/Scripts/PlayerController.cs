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
        input = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(input * speed * Time.deltaTime * 10f,0));
    }
}
