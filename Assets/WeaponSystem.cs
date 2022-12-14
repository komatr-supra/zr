using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] Rocket[] rockets;    
    int index = 0;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(index >= rockets.Length) return;            
            rockets[index].Fire();
            rockets[index] = null;
            index++;
        }
    }
}
