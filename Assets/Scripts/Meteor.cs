using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Snow"))
        {
            GameManager.instance.DestroySnowBalls();
            Destroy(gameObject);
        }

    }
}
