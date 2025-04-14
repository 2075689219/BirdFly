using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // 障碍物预制体
    public GameObject player; //鸟

    public float initialSpawnInterval = 2f;// 初始生成间隔
    [SerializeField] private float obstacleZ = 15f;
    [SerializeField] private float minY = -1f, maxY = 3f;

    private float timer = 0f;
    private float spawnInterval; // 当前生成间隔

    void Start()
    {
        spawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;

            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPos = new Vector3(0, randomY, player.transform.position.z + obstacleZ); // 随机生成y轴位置
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            newObstacle.GetComponent<ObstacleMove>().target = player.gameObject;
            // 动态减少生成间隔，增加难度
            spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.01f);
        }
    }
}
