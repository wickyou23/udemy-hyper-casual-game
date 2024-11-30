using TMPro;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public enum BonusType { Addition, Subtraction, Multiplication, Division }

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider doorCollider;

    [Header("Settings")]
    [SerializeField] private BonusType rightBonus;
    [SerializeField] private int rightBonusAmount;
    [SerializeField] private BonusType leftBonus;
    [SerializeField] private int leftBonusAmount;
    [SerializeField] private Color positiveDoorColor;
    [SerializeField] private Color nagativeDoorColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConfigureDoor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ConfigureDoor()
    {
        //Right
        switch (rightBonus)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = positiveDoorColor;
                rightDoorText.text = "+" + rightBonusAmount;
                break;
            case BonusType.Subtraction:
                rightDoorRenderer.color = nagativeDoorColor;
                rightDoorText.text = "-" + rightBonusAmount;
                break;
            case BonusType.Multiplication:
                rightDoorRenderer.color = positiveDoorColor;
                rightDoorText.text = "x" + rightBonusAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color = nagativeDoorColor;
                rightDoorText.text = "/" + rightBonusAmount;
                break;
        }

        //Left
        switch (leftBonus)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = positiveDoorColor;
                leftDoorText.text = "+" + leftBonusAmount;
                break;
            case BonusType.Subtraction:
                leftDoorRenderer.color = nagativeDoorColor;
                leftDoorText.text = "-" + leftBonusAmount;
                break;
            case BonusType.Multiplication:
                leftDoorRenderer.color = positiveDoorColor;
                leftDoorText.text = "x" + leftBonusAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color = nagativeDoorColor;
                leftDoorText.text = "/" + leftBonusAmount;
                break;
        }
    }

    public void DisableCollider()
    {
        doorCollider.enabled = false;
    }

    public BonusType GetBonus(Transform runner)
    {
        if (runner.position.x < 0)
            return rightBonus;
        else
            return leftBonus;
    }

    public int GetBonusAmount(Transform runner)
    {
        if (runner.position.x < 0)
            return rightBonusAmount;
        else
            return leftBonusAmount;
    }
}
