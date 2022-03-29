using UnityEngine;

public class Snowball : MonoBehaviour
{
    private PolygonCollider2D coll;
    public Transform rayOrigin1;
    public Transform rayOrigin2;

    public bool leftRay;
    public bool rightRay;

    private void Start()
    {
        coll = gameObject.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        CheckTop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, .1f);
        }
    }

    public void CheckTop()
    {
        //RaycastHit2D hit = Physics2D.Raycast(coll.points[5], Vector2.up);

        RaycastHit2D hitLeft = Physics2D.Raycast(rayOrigin1.position, Vector2.up);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.gameObject.CompareTag("Snow") && hitLeft.collider != coll)
            {
                if (hitLeft.distance <= .1f)
                {
                    leftRay = true;
                }
                else
                {
                    leftRay = false;
                }
            }
        }

        RaycastHit2D hitRight = Physics2D.Raycast(rayOrigin2.position, Vector2.up);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.gameObject.CompareTag("Snow") && hitRight.collider != coll)
            {
                if (hitRight.distance <= .1f)
                {
                    rightRay = true;
                }
                else
                {
                    rightRay = false;
                }
            }
        }



        if (leftRay)
        {
            Debug.DrawRay(rayOrigin1.position, Vector2.up, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOrigin1.position, Vector2.up, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOrigin2.position, Vector2.up, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOrigin2.position, Vector2.up, Color.red);
        }

    }
}
