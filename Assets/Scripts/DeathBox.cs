using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    void OnTriggerEnter (Collider col)
    {
        GM.instance.LoseLife();
    }
}
