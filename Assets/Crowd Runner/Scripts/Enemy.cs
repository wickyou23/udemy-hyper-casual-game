using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { idle, run }

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float searchRadius;

    private State state = State.idle;
    private Transform target;

    [Header("Events")]
    public static Action onRunnerDestroyed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ManagerState();
    }

    private void ManagerState()
    {
        switch (state)
        {
            case State.idle:
                SearchForTarget();
                break;
            case State.run:
                MoveToPlayer();
                break;
        }
    }

    private void SearchForTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                    continue;

                runner.SetTarget();
                target = runner.transform;

                StartRunningTowardsTarget();
            }
        }
    }

    private void StartRunningTowardsTarget()
    {
        state = State.run;
        GetComponent<Animator>().Play("Run");
    }

    private void MoveToPlayer()
    {
        if (target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            onRunnerDestroyed?.Invoke();

            transform.SetParent(null);
            target.SetParent(null);

            Destroy(transform.gameObject);
            Destroy(target.gameObject);
        }
    }
}
