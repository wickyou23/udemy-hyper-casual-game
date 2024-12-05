using System;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static Action onCoinCollected;

    [Header("Elements")]
    [SerializeField] private Collider coinCollider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void HandleCoinCollected()
    {
        coinCollider.enabled = false;
        onCoinCollected?.Invoke();

        Animator animator = transform.GetComponent<Animator>();
        animator.speed = 5;

        Vector3 moveUp = new Vector3(0, 2, 0);
        LeanTween.move(gameObject, transform.position + moveUp, .2f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
        {
            transform.SetParent(null);
            Destroy(gameObject);
        });
    }
}
