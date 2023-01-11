using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyList;
    [SerializeField] private List<GameObject> EnemyOBJ;
    [SerializeField] private int SpawnCount = 5;
    private MapManager mapManager;
    private BoxCollider2D col;
    public ParticleSystem parts;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        mapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnemyDespawn(){
        SoundManager.Instance.SFXPlay(0);
        foreach (GameObject CurrentEnemy in EnemyList)
        {
            Destroy(CurrentEnemy);
        }
        parts.Play();
        EnemyList.Clear();
    }

    public void EnemySpawn()
    {
        mapManager.MagicPoof[1].Play();
        int ran;
        GameObject enemy;
        for (int i = 0; i < SpawnCount; i++)    
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
        Vector3 RandomPostion = new Vector3(range_X, range_Y, 0);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            mapManager.isMap = true;
            mapManager.IsPlayerHere = true;
            EnemySpawn();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            mapManager.isMap = false;
            mapManager.IsPlayerHere = false;
        }
    }
}
