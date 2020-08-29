using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnife : MonoBehaviour
{
    public ThrowableEntity[] knifesStorage;
    public int indexKnife;
    public ThrowableEntity currentKnife;
    public delegate void OnThrowKnife();
    public OnThrowKnife onThrow = delegate { };
    [SerializeField]
    private bool hasInteracted = false;

    private void Start()
    {
        onThrow += IncrementKnife;
        knifesStorage = GetComponentsInChildren<ThrowableEntity>();
        for (int i = 1; i < knifesStorage.Length; i++)
        {
            knifesStorage[i].gameObject.SetActive(false);
        }
        currentKnife = knifesStorage[indexKnife];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (indexKnife < knifesStorage.Length)
            {
                hasInteracted = true;
                currentKnife.Move();
                onThrow();
            }
        }
    }

    public void IncrementKnife()
    {
        if (indexKnife < knifesStorage.Length-1)
            indexKnife++;
        else
            Debug.Log(gameObject.name + " out of knifes");

        currentKnife = knifesStorage[indexKnife];
        currentKnife.gameObject.SetActive(true);
    }
}
