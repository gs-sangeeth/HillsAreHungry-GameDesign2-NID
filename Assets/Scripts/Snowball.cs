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

    private void Start()
    {
        coll = gameObject.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        //CheckBottom();
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
        bool leftRay = false;
        bool rightRay = false;


        RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginTopLeft.position, Vector2.up);
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

        RaycastHit2D hitRight = Physics2D.Raycast(rayOriginTopRight.position, Vector2.up);
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
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up, Color.red);
        }

    }

    private void CheckBottom()
    {
        //RaycastHit2D hit = Physics2D.Raycast(coll.points[5], Vector2.up);
        bool leftRay = false;
        bool rightRay = false;


        RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginBottomLeft.position, Vector2.down);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.gameObject.CompareTag("Player") && hitLeft.collider != coll)
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

        RaycastHit2D hitRight = Physics2D.Raycast(rayOriginBottomRight.position, Vector2.down);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.gameObject.CompareTag("Player") && hitRight.collider != coll)
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

        if (leftRay || rightRay)
        {
            SnowBallCounter.instance.snowBallCount = 1;
            Debug.Log(SnowBallCounter.instance.snowBallCount);

            CheckTop();
        }


        if (leftRay)
        {
            Debug.DrawRay(rayOriginBottomLeft.position, Vector2.down, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginBottomLeft.position, Vector2.down, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOriginBottomRight.position, Vector2.down, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginBottomRight.position, Vector2.down, Color.red);
        }
    }

    public void CheckTopTest()
    {
        //RaycastHit2D hit = Physics2D.Raycast(coll.points[5], Vector2.up);
        bool leftRay = false;
        bool rightRay = false;


        RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginTopLeft.position, Vector2.up);
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

        RaycastHit2D hitRight = Physics2D.Raycast(rayOriginTopRight.position, Vector2.up);
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

        //if (leftRay || rightRay)
        //{
        //    if (leftRay)
        //    {
        //        SnowBallCounter.instance.snowBallCount++;
        //        Debug.Log(SnowBallCounter.instance.snowBallCount);

        //        hitLeft.collider.gameObject.GetComponent<Snowball>().CheckTop();
        //    }
        //    else if (rightRay)
        //    {
        //        SnowBallCounter.instance.snowBallCount++;
        //        Debug.Log(SnowBallCounter.instance.snowBallCount);

        //        hitRight.collider.gameObject.GetComponent<Snowball>().CheckTop();
        //    }
        //}


        if (leftRay)
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopLeft.position, Vector2.up, Color.red);
        }

        if (rightRay)
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up, Color.green);
        }
        else
        {
            Debug.DrawRay(rayOriginTopRight.position, Vector2.up, Color.red);
        }

    }
}
