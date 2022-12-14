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
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        turret.target = player.transform.position + player.transform.forward.normalized * (Vector3.Distance(transform.position, player.transform.position));
        if(timer > fireRate)
        {
            timer = 0;
            Instantiate(bullet, endBarell.position, barell.rotation);
            
        }
        

    }
}
