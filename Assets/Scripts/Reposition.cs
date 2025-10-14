using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Area"))
        {
            Vector3 playerPos = GameManager.instance.player.transform.position;
            Vector3 myPos = transform.position;

            float diffX = Mathf.Abs(playerPos.x - myPos.x);
            float diffY = Mathf.Abs(playerPos.y - myPos.y);
            //X축과 Y축에서 서로 얼마나 떨어져있는지 절대값으로 계산

            Vector3 playerDir = GameManager.instance.player.inputVec; //플레이어의 입력값
            float dirX = playerDir.x < 0 ? -1 : 1; //플레이어가 왼쪽으로 이동중이면 -1, 아니면 +1
            float dirY = playerDir.y < 0 ? -1 : 1; //플레이어가 아래로 이동중이면 -1, 아니면 +1


            if (diffX > diffY)
            {
                transform.Translate(Vector3.right * dirX * 60);
                //X축 거리 차리가 더 크면 X축 방향으로 60만큼 이동
            }
            else if (diffX < diffY)
            {
                transform.Translate(Vector3.up * dirY * 60);
                //Y축 거리 차이가 더 크면 Y축 방향으로 이동
            }
        }
    }
}
