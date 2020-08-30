using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvoidInteraction : InteractionBehaviour
{
    public override void Start()
    {
        base.Start();
        interactionEvent += HarmInteraction;
    }

    public void HarmInteraction(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
