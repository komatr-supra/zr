using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Transform gun1;
    [SerializeField] ParticleSystem gun1par;
    [SerializeField] ParticleSystem gun2par;
    [SerializeField] Transform gun2;
    [SerializeField] GameObject bullet;
    [SerializeField] float xClamp = 8f;
    [SerializeField] float yClamp = 5.5f;
    [SerializeField] float xAim = 1.2f;
    [SerializeField] float yAim = 1.2f;
    [SerializeField] AudioClip[] ShootsAudioClips;
    [SerializeField] Transform aim;
    [SerializeField] float aimPos = 10f;

    Vector2 mouseDelta = Vector2.zero;
    Vector2 moveVector = Vector2.zero;
    float rotationZ;
    float rotationX;
    float rotationY;

    [SerializeField] float moveDelay = 0.1f;
    [SerializeField] float rotationSpeed = 0.01f;
    [SerializeField] GameObject aimCanvas;

    private void OnEnable() {
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
    }
    private void Update()
    {
        var localTransform = transform.localPosition;

        HandleMovement(localTransform);

        rotationZ = Mathf.Lerp(rotationZ, -mouseDelta.x, rotationSpeed);
        rotationZ = Mathf.Clamp(rotationZ, -60, 60);

        rotationX = Mathf.Lerp(rotationX, -mouseDelta.y, rotationSpeed);
        rotationX = Mathf.Clamp(rotationX, -10, 10);

        rotationY = Mathf.Lerp(rotationY, -mouseDelta.x, rotationSpeed);
        rotationY = Mathf.Clamp(rotationY, -10, 10);

        


        transform.localRotation = Quaternion.Euler(-localTransform.y * xAim + rotationX, localTransform.x * yAim - rotationY, rotationZ); //-mouseDelta.x * 15

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bullet, gun1.position, transform.rotation);      
            Instantiate(bullet, gun2.position, transform.rotation);
            int rnd = Random.Range(0, ShootsAudioClips.Length);
            AudioSource.PlayClipAtPoint(ShootsAudioClips[rnd], transform.position, 0.1f);
            gun1par.Play();
            gun2par.Play();
        }


        
        aim.position = transform.position + transform.forward.normalized * aimPos;
        aimCanvas.transform.position = Camera.main.WorldToScreenPoint(aim.position);

    }
    public void OnLookInput(InputAction.CallbackContext data)
    {
        mouseDelta = data.ReadValue<Vector2>();
    }

    private void HandleMovement(Vector3 localTransform)
    {   
        moveVector = Vector2.Lerp(moveVector, mouseDelta, moveDelay);

        float xNew = Mathf.Clamp((localTransform.x + moveVector.x * moveSpeed * Time.deltaTime), -xClamp, xClamp);
        float yNew = Mathf.Clamp((localTransform.y + moveVector.y * moveSpeed * Time.deltaTime), -yClamp, yClamp);
        transform.localPosition = new Vector3(xNew, yNew, 0);
    }

    
}
