using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvoidInteraction : InteractionBehaviour
{
    public string avoidTag;

    public override void Start()
    {
        base.Start();
        interactionEvent += HarmInteraction;
    }

    public void HarmInteraction(Collider2D col)
    {
        if (col.CompareTag(avoidTag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
