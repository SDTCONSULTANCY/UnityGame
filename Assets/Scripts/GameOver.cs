using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public bool isDied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            Time.timeScale = 0;
            isDied = true;
            GameManager.InvokeFail();
        }
    }
}
