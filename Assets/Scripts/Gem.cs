using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] GameObject visual;
    [SerializeField] ParticleSystem particles;

    bool collected = false;

    public void Collect()
    {
        if (collected)
            return;

        collected = true;

        visual.SetActive(false);
        particles.Play();
        Destroy(gameObject, 5);
    }
}
