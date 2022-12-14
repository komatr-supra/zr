using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float destroyTime = 1.2f;
    private void Start()
    {
        int rndIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[rndIndex]);
        Destroy(gameObject, destroyTime);
    }    
}
