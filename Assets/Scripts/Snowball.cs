using UnityEngine;

public class Snowball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            print("destroy");
            Destroy(gameObject, 2f);
        }
    }
}
