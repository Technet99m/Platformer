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

}
