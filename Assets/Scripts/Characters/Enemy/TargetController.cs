using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private Vector2 targetPos;
    private bool hasTarget;
    public bool HasTarget { get { return hasTarget; } }

    public Vector2 dir { get{ return hasTarget ? (targetPos - (Vector2)transform.position).normalized:Vector2.zero; } }
    public float dirX { get { return hasTarget ? (targetPos.x > transform.position.x ? 1 : -1): 0; } }

    public void SetTarget(Vector2 pos)
    {
        targetPos = pos;
        hasTarget = true;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, targetPos) < 0.03f)
            hasTarget = false;
    }
    private void Start()
    {
        StartCoroutine(RandomWalk());
    }
    IEnumerator RandomWalk()
    {
        while (true)
        {
            SetTarget(new Vector2(Random.Range(-5f, 5f), transform.position.y));
            yield return new WaitForSeconds(5f);
        }
    }
}
