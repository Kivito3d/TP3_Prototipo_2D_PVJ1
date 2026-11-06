using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float timeOffset;
    [SerializeField] private EnemyData enemyData;

    private void Start()
    {
        if (enemyData != null)
        {
            timeSpawn = enemyData.ShootFrequency;
        }
        InvokeRepeating("Spawn",timeOffset,timeSpawn);
    }

    private void Spawn()
    {
        Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, -90f));
    }
}
