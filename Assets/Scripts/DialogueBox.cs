using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [HideInInspector]
    public int demand;

    public Text text;

    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        demand = Random.Range(2, 7);
        text.text = demand.ToString();

        coll = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == coll)
            {
                if(GameManager.instance.snowBallCount >= demand)
                {
                    GameManager.instance.DestroySnowBalls(demand);
                    DialogueBoxSpawner.instance.StartTimer();
                    Destroy(gameObject);
                }
            }
        }
    }
}
