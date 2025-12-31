using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Boss bossPrefab;
    public List<Enemy> enemies;
    private int numDeadNem;// quanti nemici sono morti
    private int globalNumEnemy;//mi segna qaunti nemici sono esistiti all'inizio del gioco

    private void Start()
    {
        globalNumEnemy=enemies.Count;
    }
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        numDeadNem++;
        if(numDeadNem==globalNumEnemy)
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
