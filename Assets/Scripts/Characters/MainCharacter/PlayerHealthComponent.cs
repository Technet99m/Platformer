using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : HealthComponent
{
    public override void Die()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border"))
            Die();
    }
}
