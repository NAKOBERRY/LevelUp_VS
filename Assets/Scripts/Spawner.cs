using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDistance; //플레이어랑 얼마나 떨어져서 몬스터가 스폰되는가


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }


    private void Spawn()
    {
        var player = GameManager.instance.player;

        float angle = Random.Range(0, 360); //0부터 360의 랜덤한 수를 가져와서 앵글 변수에 담는다
        float angleRadians = angle * Mathf.Deg2Rad;

        float spawnX = player.transform.position.x + Mathf.Cos(angleRadians) * spawnDistance;
        float spawnY = player.transform.position.y + Mathf.Sin(angleRadians) * spawnDistance;

        Vector3 spawnPosition = new Vector3(spawnX, spawnY);

        GameObject enemy = PoolManager.instance.Get(0); //오브젝트 추가됨
        enemy.transform.position = spawnPosition;
    }
}
