using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupEnemy : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Transform enemiesParent;



    [Header("Settings")]
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomEnemyCount = Random.Range(1, Mathf.Max(maxEnemyCount, 1));
        for (int i = 0; i < randomEnemyCount; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, enemiesParent);
            enemy.transform.localPosition = GetRunnerPostion(i);
            enemy.transform.localRotation = Quaternion.Euler(0, Random.Range(135, 225), 0);
        }

        textMeshPro.text = randomEnemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesParent.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GetRunnerPostion(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(angle * index * Mathf.Deg2Rad);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(angle * index * Mathf.Deg2Rad);
        return new Vector3(x, 0, z);
    }
}
