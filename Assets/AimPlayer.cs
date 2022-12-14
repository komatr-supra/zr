using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour
{
    [SerializeField] Turret turret;
    [SerializeField] GameObject player;
    [SerializeField] Transform endBarell; 
    [SerializeField] Transform barell;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float size = 2;
    [SerializeField] AudioClip[] ac;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 vec = Random.insideUnitSphere * size;
        turret.target = player.transform.position + player.transform.forward.normalized *
        (((Vector3.Distance(transform.position, player.transform.position) / 100) * 15)) + vec;
        ;
        if(timer > fireRate)
        {
            timer = 0;
            Instantiate(bullet, endBarell.position, barell.rotation);
            AudioSource.PlayClipAtPoint(ac[Random.Range(0, ac.Length)], transform.position);
        }
        

    }
}
