using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThrowKnife : MonoBehaviour
{
    public ThrowableEntity[] knifesStorage;
    public int indexKnife;
    public ThrowableEntity currentKnife;

    public Transform knifeStartPosition;
    public Transform knifeMenuPosition;


    public delegate void OnThrowKnife();
    public OnThrowKnife onThrow = delegate { };

    [SerializeField]
    private bool hasInteracted = false;
    [SerializeField]
    private int knifesLeft;

    private EventSystem eventSystem;
    private GameObject objectSelected;
    private Button buttonSelected;


    private void Start()
    {
        onThrow += IncrementKnife;
        knifesStorage = GetComponentsInChildren<ThrowableEntity>();
        knifesLeft = knifesStorage.Length;
        eventSystem = EventSystem.current;

        for (int i = 1; i < knifesStorage.Length; i++)
        {
            knifesStorage[i].gameObject.SetActive(false);
        }
        currentKnife = knifesStorage[indexKnife];
    }

    public void Throw()
    {
        if (GameStatus.gameActive)
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
        knifesLeft--;
        knifesLeft = Mathf.Clamp(knifesLeft, 0, knifesStorage.Length);
        Debug.Log("KnivesLeft " + knifesLeft);
        Debug.Log("IndexKnife " + indexKnife);


        if (indexKnife < knifesStorage.Length - 1)
            indexKnife++;
        else
            Debug.Log(gameObject.name + " out of knifes");

        currentKnife = knifesStorage[indexKnife];
        currentKnife.gameObject.SetActive(true);
    }

    public int GetKnifesLeft()
    {
        return knifesLeft;
    }

    public void SetKnifePosition(int index, Vector3 position)
    {
        knifesStorage[index].RestartInteraction();
        knifesStorage[index].transform.position = position;
    }
    public void RestartKnifesThrow()
    {
        indexKnife = 0;
        knifesLeft = knifesStorage.Length;
        currentKnife = knifesStorage[0];
    }
}
