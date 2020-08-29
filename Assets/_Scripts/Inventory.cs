using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private ThrowKnife throwKnife;

    void Start()
    {
        throwKnife = GetComponent<ThrowKnife>();
    }

    void Update()
    {
        
    }
}
