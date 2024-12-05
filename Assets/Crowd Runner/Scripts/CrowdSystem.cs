using System;
using Unity.VisualScripting;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform parentRunner;
    [SerializeField] private GameObject runnerPrefab;
    [SerializeField] private PlayerAnimator playerAnimator;

    [Header("Settings")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunners();
    }

    private void PlaceRunners()
    {
        for (int i = 0; i < parentRunner.childCount; i++)
        {
            parentRunner.GetChild(i).localPosition = GetRunnerPostion(i);
        }
    }

    private Vector3 GetRunnerPostion(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(angle * index * Mathf.Deg2Rad);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(angle * index * Mathf.Deg2Rad);
        return new Vector3(x, 0, z);
    }

    public float GetGroundRadius()
    {
        return radius * Mathf.Sqrt(parentRunner.childCount);
    }

    public void HandleBonus(Doors.BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case Doors.BonusType.Addition:
                AddRunner(bonusAmount);
                break;
            case Doors.BonusType.Division:
                {
                    int mBonusAmount = parentRunner.childCount - parentRunner.childCount / bonusAmount;
                    RemoveRunner(mBonusAmount);
                    break;
                }
            case Doors.BonusType.Multiplication:
                {
                    int mBonusAmount = (parentRunner.childCount * bonusAmount) - parentRunner.childCount;
                    AddRunner(mBonusAmount);
                    break;
                }

            case Doors.BonusType.Subtraction:
                RemoveRunner(bonusAmount);
                break;
        }
    }

    private void AddRunner(int bonusAmount)
    {
        for (int i = 0; i < bonusAmount; i++)
        {
            Instantiate(runnerPrefab, parentRunner);
        }

        playerAnimator.Run();
    }

    private void RemoveRunner(int bonusAmount)
    {
        if (bonusAmount > parentRunner.childCount)
            bonusAmount = parentRunner.childCount;

        if (bonusAmount == parentRunner.childCount)
            bonusAmount -= 1;

        int numOfRunners = parentRunner.childCount;
        for (int i = numOfRunners - 1; i >= numOfRunners - bonusAmount; i--)
        {
            Transform runner = parentRunner.GetChild(i);
            runner.SetParent(null);
            Destroy(runner.gameObject);
        }
    }
}
