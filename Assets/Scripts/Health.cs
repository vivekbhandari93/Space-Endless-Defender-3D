using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int GetHealth() { return health; }

    public int ReduceHealth(int damage) { return health -= damage; }

}
