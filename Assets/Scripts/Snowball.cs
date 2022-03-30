using UnityEngine;

public class Snowball : MonoBehaviour
{
    private PolygonCollider2D coll;

    // Top
    public Transform rayOriginTopLeft;
    public Transform rayOriginTopRight;

    // Bottom
    public Transform rayOriginBottomLeft;
    public Transform rayOriginBottomRight;

    [SerializeField]
    LayerMask snowBallLayerMask;
    [SerializeField]
    LayerMask playerLayerMask;

    private void Start()
    {
        coll = gameObject.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        CheckBottom();
        CheckTopTest();
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
        bool leftRay = false;
        bool rightRay = false;


        RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginTopLeft.position, Vector2.up, .2f, snowBallLayerMask);
        if (hitLeft.collider != null)
        {
            if (hitLeft.normal == Vector2.down)
            {
                leftRay = true;
            }
            else
            {
                leftRay = false;
            }
        }

        RaycastHit2D hitRight = Physics2D.Raycast(rayOriginTopRight.position, Vector2.up, .2f, snowBallLayerMask);
        if (hitRight.collider != null)
        {
            if (hitRight.normal == Vector2.down)
            {
                rightRay = true;
            }
            else
            {
                rightRay = false;
            }
        }

        if (leftRay || rightRay)
        {
            if (leftRay)
            {
                SnowBallCounter.instance.snowBallCount++;
                Debug.Log(SnowBallCounter.instance.snowBallCount);

                hitLeft.collider.gameObject.GetComponent<Snowball>().CheckTop();
            }
            else if (rightRay)
            {
                SnowBallCounter.instance.snowBallCount++;
                Debug.Log(SnowBallCounter.instance.snowBallCount);

                hitRight.collider.gameObject.GetComponent<Snowball>().CheckTop();
            }
        }


        if (leftRay)
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up * .2f, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up * .2f, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up * .2f, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up * .2f, Color.red);
        }

    }

    private void CheckBottom()
    {
        bool leftRay = false;
        bool rightRay = false;


        RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginBottomLeft.position, Vector2.down,.2f, playerLayerMask);
        if (hitLeft.collider != null)
        {
            if (hitLeft.normal == Vector2.up)
            {
                leftRay = true;
            }
            else
            {
                leftRay = false;
            }
        }

        RaycastHit2D hitRight = Physics2D.Raycast(rayOriginBottomRight.position, Vector2.down,.2f, playerLayerMask);
        if (hitRight.collider != null)
        {
            if (hitRight.normal == Vector2.up)
            {
                rightRay = true;
            }
            else
            {
                rightRay = false;
            }
        }

        if (leftRay || rightRay)
        {
            SnowBallCounter.instance.snowBallCount = 1;
            Debug.Log(SnowBallCounter.instance.snowBallCount);

            CheckTop();
        }


        if (leftRay)
        {
            Debug.DrawRay(rayOriginBottomLeft.position, Vector2.down * .2f, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginBottomLeft.position, Vector2.down * .2f, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOriginBottomRight.position, Vector2.down * .2f, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginBottomRight.position, Vector2.down * .2f, Color.red);
        }
    }

    public void CheckTopTest()
    {
        bool leftRay = false;
        bool rightRay = false;


        RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginTopLeft.position, Vector2.up,.2f, snowBallLayerMask);
        if (hitLeft.collider != null)
        {
            if (hitLeft.normal == Vector2.down)
            {
                leftRay = true;
            }
            else
            {
                leftRay = false;
            }
        }

        RaycastHit2D hitRight = Physics2D.Raycast(rayOriginTopRight.position, Vector2.up,.2f, snowBallLayerMask);
        if (hitRight.collider != null)
        {
            if (hitRight.normal == Vector2.down)
            {
                rightRay = true;
            }
            else
            {
                rightRay = false;
            }
        }

        if (leftRay)
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up * .2f, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up * .2f, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up * .2f, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up * .2f, Color.red);
        }

    }
}
