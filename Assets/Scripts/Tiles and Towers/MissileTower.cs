using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTower : AttackTower
{
    // Start is called before the first frame update
    void Start()
    {
        attackPrefab = Resources.Load<GameObject>("Attacks/MissileTowerAttack");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
