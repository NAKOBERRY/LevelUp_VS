using UnityEngine;

public class RepositionEnemy : MonoBehaviour
{
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Area"))
        {
            Vector3 playerDir = GameManager.instance.player.inputVec;
            if(col.enabled)
            {
                transform.Translate(playerDir * 30 + new Vector3(Random.Range(-4, 4f), Random.Range(-4, 4f)));
            }
        }
    }
}
