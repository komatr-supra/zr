using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] GameObject explosion;
    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        float frameDistance = speed * Time.deltaTime;
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo,frameDistance))
        {
            Instantiate(explosion, hitInfo.point, Quaternion.identity);            
            Destroy(gameObject);
            if(hitInfo.collider.transform.parent != null && hitInfo.collider.transform.parent.TryGetComponent<Health>(out Health health))
            {
                health.TakeDmg(1);
            }
        }
        transform.position += transform.forward * frameDistance;
    }
    
}
