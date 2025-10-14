using Unity.Cinemachine;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Scanner scanner;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float damage;

    private float attackTimer;

    private void Update()
    {
        attackTimer = Time.deltaTime;

        if(attackTimer > attackSpeed)
        {
            Fire();
            attackTimer = 0;
        }
    }

    private void Fire()
    {
        if(!scanner.nearestTarget) return; //스캐너에 잡히는 오브젝트가 없으면 함수 실행 안 함

        Vector3 targetPos = scanner.nearestTarget.position; //타겟 위치 저장
        Vector3 dir = targetPos - transform.position; //타겟 위치 - 플레이어 위치로 거리, 방향 계산

        dir = dir.normalized; //계산한 거리와 방향을 가진 백터를 방향 백터로 바꿈(거리를 1로 바꿈)

        GameObject bullet = PoolManager.instance.Get(1); //탄환 소환
        bullet.transform.position = transform.position; //탄환이 처음 생기는 위치를 플레이어로 고정
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir); //탄환의 방향을 타겟으로 향하게 바꿈
        bullet.GetComponent<Bullet>().Init(damage, dir); //탄환의 대미지를 설정함
    }
}
