using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    public Vector2 inputVec;
    [SerializeField] private float speed;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        InputVec();
    }
   
    private void FixedUpdate() 
    {
        PlayerMove();
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
