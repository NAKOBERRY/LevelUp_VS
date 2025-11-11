using UnityEditor.Rendering;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField] private Rigidbody2D target;

    [SerializeField] private float speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Tracking();
    }

    private void Tracking()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

}
