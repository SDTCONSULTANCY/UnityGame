using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collect : MonoBehaviour
{
    GameObject player_cube;
    public int height;

    void Start()
    {
        player_cube = GameObject.Find("player_cube");
    }

    void Update()
    {
        player_cube.transform.DOMoveY(height + 1, .5f);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Catch" && other.gameObject.GetComponent<Collect_Balls>().GetIsAdded() == false) 
        {
            height += 1;
            other.gameObject.GetComponent<Collect_Balls>().MakeAdded();
            other.gameObject.GetComponent<Collect_Balls>().SetIndex(height);
            other.gameObject.GetComponent<Collect_Balls>().transform.parent = player_cube.transform;
        }

        if (other.gameObject.tag == "Gem" && other.TryGetComponent<Gem>(out var gem)) 
        {
            gem.Collect();
            GameManager.Gems++;
        }
    }
}
