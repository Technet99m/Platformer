using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotStablePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player") && transform.position.y<collision.transform.position.y)
        {
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
