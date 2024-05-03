using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100.0f;
    [SerializeField] float moveSpeed = 5f;
    Vector3 rotateValue;

    void Start()
    {

    }

    void Update()
    {
        moving();
        rotating();
        cursorMode();
    }

    private void moving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += transform.rotation * Vector3.forward * moveSpeed * Time.deltaTime;//±Û·Î¹úÁÂÇ¥ * È¸Àü°ª
            //transform.position += transform.TransformDirection(Vector3.forward) * moveSpeed * Time.deltaTime;
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.rotation * Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.rotation * Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.rotation * Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }

    private void cursorMode()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void rotating()
    {
        if (Cursor.lockState != CursorLockMode.Locked) return;

        float mouseX = Input.GetAxisRaw("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateValue.x -= mouseY;
        rotateValue.y += mouseX;

        rotateValue.x = Mathf.Clamp(rotateValue.x, -45, 45);

        transform.rotation = Quaternion.Euler(rotateValue);
    }
}
