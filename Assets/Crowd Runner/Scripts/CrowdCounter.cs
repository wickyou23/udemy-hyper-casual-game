using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform runners;
    [SerializeField] private TextMeshPro textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = runners.childCount.ToString();

        if (runners.childCount == 0)
        {
            GameManager.Instance.ChangeGameState(GameManager.GameState.GameOver);
            Destroy(transform.gameObject);
        }
    }
}
