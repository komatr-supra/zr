using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponable
{
    public void Fire();
}

public class Rocket : MonoBehaviour, IWeaponable
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject[] objEnabled;
    [SerializeField] float speed = 100f;

    bool isFired = false;
    [SerializeField] AudioClip fireEffect;    
    [SerializeField] GameObject rocketSound;
    public void Fire()
    {
        transform.parent = null;
        isFired = true;
        AudioSource.PlayClipAtPoint(fireEffect, transform.position);
        foreach (var item in objEnabled)
        {
            item.SetActive(true);
        }
        Invoke("EnableSound", 0.2f);
    }

    private void Update()
    {
        if(!isFired) return;
        CollisionHandle();
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void EnableSound()
    {
        rocketSound.SetActive(true);
    }

    private void CollisionHandle()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo,speed * Time.deltaTime))
        {
            Instantiate(explosion, hitInfo.point, Quaternion.identity);
            objEnabled[0].transform.parent = null;
            Destroy(objEnabled[0], 0.9f);
            objEnabled[0] = null;
            Destroy(gameObject);
        }
    }
}
