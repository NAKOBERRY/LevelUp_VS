using Unity.Android.Gradle;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float scanRange;

    public Transform nearestTarget;

    private void FixedUpdate()
    {
        nearestTarget = GetNearest();
    }

    public Transform GetNearest()
    {
        Transform result = null; //타겟을 담을 지역 변수
        float distance = 99999999; //타겟의 거리를 담을 변수(999...는 임시)

        RaycastHit2D[] targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        //스캔 거리 안에 있는 타겟레이어를 지닌 모든 오브젝트를 targets라는 배열에 담음

        foreach(var target in targets) //targets배열에 담긴 모든 오브젝트와 플레이어 간의 직선 거리를 구함
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;

            float curDistance = (targetPos - myPos).sqrMagnitude; //sqrMagnitude는 그냥 직선 거리 구하는 공식
            //이렇게 구한 거리를 curDistance에 저장

            if(curDistance < distance)//curDistance의 크기가 distance보다 작으면 
            {
                distance = curDistance; //curDistance를 distance로 교체
                result = target.transform; //현재 타겟을 결과로 변경
            }
        }
        return result;
    }
}
