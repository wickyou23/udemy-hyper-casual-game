using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;

    [Header("Events")]
    public static Action<Doors.BonusType> onDoorDetected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameState)
            OnDoorsDetected();
    }

    private void OnDoorsDetected()
    {
        Collider[] detectionColliders = Physics.OverlapSphere(transform.position, MathF.Max(crowdSystem.GetGroundRadius(), 1));
        for (int i = 0; i < detectionColliders.Length; i++)
        {
            if (detectionColliders[i].TryGetComponent(out Doors doors))
            {
                doors.DisableCollider();

                Doors.BonusType bonusType = doors.GetBonus(transform);
                int bonusAmount = doors.GetBonusAmount(transform);

                onDoorDetected?.Invoke(bonusType);

                crowdSystem.HandleBonus(bonusType, bonusAmount);
            }
            else if (detectionColliders[i].tag == "Finish")
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);

                GameManager.Instance.ChangeGameState(GameManager.GameState.LevelCompleted);
            }
            else if (detectionColliders[i].TryGetComponent(out Coin coin))
            {
                coin.HandleCoinCollected();
            }
        }
    }
}
