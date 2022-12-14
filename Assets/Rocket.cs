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
        float frameDistance = speed * Time.deltaTime;
        CollisionHandle(frameDistance);
        transform.position += transform.forward * frameDistance;
    }
    void EnableSound()
    {
        rocketSound.SetActive(true);
    }

    private void CollisionHandle(float frameDistance)
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo,frameDistance))
        {
            Instantiate(explosion, hitInfo.point, Quaternion.identity);
            
            objEnabled[0].transform.parent = null;
            Destroy(objEnabled[0], 0.9f);
            objEnabled[0] = null;
            Destroy(gameObject);
            if(hitInfo.collider.transform.parent != null && hitInfo.collider.transform.parent.TryGetComponent<Health>(out Health health))
            {
                health.TakeDmg(10);
            }
        }
    }
}
