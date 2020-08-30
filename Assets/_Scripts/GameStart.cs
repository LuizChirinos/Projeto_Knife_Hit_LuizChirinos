using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private GameObject managerGO;
    private ThrowKnife throwKnife;
    private GameObject enemiesParent;
    private Entity[] enemies;

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies");
        managerGO = GameObject.Find("Manager");
        throwKnife = managerGO.GetComponent<ThrowKnife>();
        enemies = enemiesParent.GetComponentsInChildren<Entity>();
    }
}
