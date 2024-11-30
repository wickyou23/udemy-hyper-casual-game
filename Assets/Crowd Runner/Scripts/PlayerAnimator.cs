using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform parentRunner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    {
        foreach (Transform child in parentRunner)
        {
            child.GetComponent<Animator>().Play("Run");
        }
    }

    public void Idle()
    {
        foreach (Transform child in parentRunner)
        {
            child.GetComponent<Animator>().Play("Idle");
        }
    }
}
