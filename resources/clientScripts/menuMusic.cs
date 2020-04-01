using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour
{
    public AudioSource aud1;
    public AudioSource aud2;
    void Start()
    {
        int r = Random.Range(0 ,2);
        if (r == 1) aud2.Play();
        if (r == 2) aud1.Play();
        if (r == 0) aud2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
