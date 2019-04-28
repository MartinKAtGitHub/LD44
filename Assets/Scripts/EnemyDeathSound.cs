using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : MonoBehaviour
{
    public AudioClip AudioClip;
    AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.clip = AudioClip;
        audioSource.pitch = Random.Range(0.60f,1.5f);
        audioSource.Play();
        Destroy(this.gameObject, 2f);
    }
}
