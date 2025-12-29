using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Boss bossPrefab;
    public List<Enemy> enemies;
    private int numDeadNem;
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        numDeadNem++;
        if(numDeadNem==enemies.Count)
        {
            SpawnBoss();
        }
        enemies.Remove(enemy);
    }

    public void SpawnBoss()
    {
        Boss boss = Instantiate(bossPrefab);
        boss.transform.position = gameObject.transform.position;
        
    }
}
