using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Catch")
        {
            if (GameManager.Gems > 2)
                GameManager.InvokeSuccess();
            else
                GameManager.InvokeFail();
        }
    }
}
