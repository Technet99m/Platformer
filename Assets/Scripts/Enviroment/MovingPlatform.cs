using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector2 pos2;
    [SerializeField] float speed;
    bool isMovingRight;
    Vector2 pos1;
    [SerializeField] float waitTime;

    void Start()
    {
        isMovingRight = true;
        pos1 = transform.position;
        waitTime += Vector2.Distance(pos1, pos2) / speed;
        StartCoroutine(ChangeDir());
    }
    private void Update()
    {
        if (isMovingRight)
            transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
    }
    IEnumerator ChangeDir()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime); 
            isMovingRight ^= true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player") && collision.transform.position.y>transform.position.y)
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
