using UnityEditor.Rendering;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private Rigidbody2D target;

    [SerializeField] private float speed;
    [SerializeField] private float maxHp;
    [SerializeField] private float curHp;

    

    private bool isLive;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {     
        curHp = maxHp;
        rigid.simulated = true;
        col.enabled = true;
        isLive = true;
    }

    private void FixedUpdate()
    {
        Tracking();
    }

    private void LateUpdate()
    {
        if (!isLive) return;

        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }

    private void Tracking()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    public void OnDamage(float damage)
    {
        curHp -= damage;
        KnockBack();

        if(curHp <= 0)
        {
            isLive = false;
            rigid.simulated = false; //물리 연산을 멈춤
            col.enabled = false; //콜라이더 끄기
            animator.SetBool("Dead", true);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }

    private void KnockBack()
    {
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        //오브젝트에 물리적인 힘을 가해주는 함수
    }

}
