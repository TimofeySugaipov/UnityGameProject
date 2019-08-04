using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeathSound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] Sounds;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        int RandomNumber = Random.Range(0, Sounds.Length);
        source.clip = Sounds[RandomNumber];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
