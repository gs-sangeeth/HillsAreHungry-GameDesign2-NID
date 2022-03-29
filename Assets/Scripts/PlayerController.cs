using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private float input;
    private float mobileInput;
    private Rigidbody2D rb;
    private BoxCollider2D playerHead;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerHead = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Get Mobile Input
        if (Input.GetMouseButton(0))
        {
            Collider2D colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (colliderHit != null)
            {
                if (colliderHit.gameObject.CompareTag("LeftMoveButton"))
                {
                    mobileInput = -1;
                }
                else if (colliderHit.gameObject.CompareTag("RightMoveButton"))
                {
                    mobileInput = 1;
                }
                else
                {
                    mobileInput = 0;
                }
            }
        }
        else
        {
            mobileInput = 0;
        }

        // Move
        input = Input.GetAxisRaw("Horizontal");
        //input = mobileInput;
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

        //if (playerHead.OverlapCollider != null)
        //{

        //}

    }


}
