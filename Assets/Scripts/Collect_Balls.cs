using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collect_Balls : MonoBehaviour
{
    private bool isAdded;
    private int index;
    [SerializeField] Collect catcher;

    void Start()
    {
        isAdded = false;
    }

    void Update()
    {
        if (isAdded)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    public bool GetIsAdded()
    {
        return isAdded;
    } 

    public void MakeAdded()
    {
        isAdded = true;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            StartCoroutine(delay(other));
        }
    }
    IEnumerator delay(Collider other)
    {
        this.transform.parent = null;
        GetComponent<BoxCollider>().enabled = false;
        other.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(.5f);
        catcher.height--;
    }
}
