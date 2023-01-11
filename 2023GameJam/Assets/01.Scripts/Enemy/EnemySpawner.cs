using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyList;
    [SerializeField] private List<GameObject> EnemyOBJ;
    [SerializeField] private int SpawnCount = 5;
    private BoxCollider2D col;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemySpawn()
    {
        foreach (GameObject CurrentEnemy in EnemyList)
        {
            Destroy(CurrentEnemy);
        }

        int ran;
        GameObject enemy;
        for (int i = 0; i > 5; i++)
        {
            ran = Random.Range(0, EnemyOBJ.Count);
            enemy = Instantiate(EnemyOBJ[ran], EnemySpawnPos(), Quaternion.identity);
            EnemyList.Add(enemy);
        }
    }

    private Vector3 EnemySpawnPos()
    {
        Vector3 originPosition = col.transform.position;

        float range_X = col.bounds.size.x;
        float range_Y = col.bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Y);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
