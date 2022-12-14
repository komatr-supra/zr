using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 2;
    [SerializeField] GameObject explosion;

    public void TakeDmg(int dmg)
    {
        hp -= dmg;
        Debug.Log(hp);
        if(hp <= 0)
        {
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 2f);
            Destroy(gameObject, 0.1f);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
