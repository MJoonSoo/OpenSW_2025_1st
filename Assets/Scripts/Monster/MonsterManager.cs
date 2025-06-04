using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // 몬스터 프리팹과 스폰 지점을 에디터에서 할당
    public GameObject monsterPrefab;
    public Transform[] spawnPoints; // 여러개의 스폰포인트를 배열로 저장장
    public List<GameObject> monsterInstance = new List<GameObject>();

    // 게임 시작 후 몬스터 생성 및 행동 시작 시간 (초 단위)
    private float spawnDelay = 0f; // spawnDelay시간 지난난 후 몬스터 생성
    private float monsterCount = 20f;

    private void Start()
    {
        Debug.Log("30초 대기");
        if (monsterInstance != null)
        {
            monsterInstance = new List<GameObject>();
        }

        foreach (GameObject monster in monsterInstance)
        {
            monster.SetActive(false);
        }
            Debug.Log("기존 몬스터 비활성화");
        // 30초 후 활성화하는 코루틴 실행
        StartCoroutine(InitializeMonster());

    }

    private IEnumerator InitializeMonster()
    {
        // spawnDelay 대기 후 몬스터 생성
        yield return new WaitForSeconds(spawnDelay);

        for (int i = 0; i < monsterCount; i++)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newMonster = Instantiate(monsterPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
            monsterInstance.Add(newMonster);

            Monster monsterScript = newMonster.GetComponent<Monster>();
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                monsterScript.player = playerObject.transform;
            }
            // 몬스터를 배회 상태로 활성화
            monsterScript.ActivateMonster();
        
        }
    }
}
