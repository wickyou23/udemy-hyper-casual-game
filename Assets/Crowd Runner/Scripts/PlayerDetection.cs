using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnDoorsDetected();
    }

    private void OnDoorsDetected()
    {
        Collider[] detectionColliders = Physics.OverlapSphere(transform.position, 1);
        for (int i = 0; i < detectionColliders.Length; i++)
        {
            if (detectionColliders[i].TryGetComponent(out Doors doors))
            {
                doors.DisableCollider();

                Doors.BonusType bonusType = doors.GetBonus(transform);
                int bonusAmount = doors.GetBonusAmount(transform);

                crowdSystem.HandleBonus(bonusType, bonusAmount);
            }
            else if (detectionColliders[i].tag == "Finish")
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
