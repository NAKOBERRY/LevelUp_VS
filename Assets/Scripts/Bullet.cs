using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private Rigidbody2D rigid;

    private float _damage;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, Vector3 dir)
    {
        rigid.linearVelocity = dir * bulletSpeed;
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<Monster>().OnDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Area"))
        {
            gameObject.SetActive(false);
        }
    }
}
