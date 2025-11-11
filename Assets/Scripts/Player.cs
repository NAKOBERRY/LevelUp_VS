using System.Diagnostics.Tracing;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    public Vector2 inputVec;
    [SerializeField] private float speed;

    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        InputVec();
    }
   
    private void FixedUpdate() //물리 계산마다 호출
    {
        PlayerMove();
    }

    private void LateUpdate() //업데이트보다 한 박자 늦게 호출됨
    {
        animator.SetBool("isRun", Mathf.Abs(inputVec.magnitude) > 0.01f);

        if (inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }
    }

    private void InputVec()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal"); 
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMove()
    {
        var newInputVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + newInputVec);
    }

}
