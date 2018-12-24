using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collision))]
public class MainActorControllor : MonoBehaviour {
    Rigidbody rb;
    float lastJumpTime;
    bool is_jumping = false;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    // Use this for initialization
    void Start ()
    {
        lastJumpTime = Time.time;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            transform.localPosition += Const.moveSpeed * Time.deltaTime * transform.forward;
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.localPosition += -1 * Const.moveSpeed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.localPosition += Const.moveSpeed * Time.deltaTime * transform.right;
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.localPosition += -1 * Const.moveSpeed * Time.deltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.Space)) {
            if (!is_jumping && Time.time - lastJumpTime > 0.5) {
                //rb.AddForce(jumpForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
                is_jumping = true;
                lastJumpTime = Time.time;
                rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
                //transform.localPosition += jumpForce * Time.deltaTime * Vector3.up;
            }
        }
        else
            lastJumpTime = Time.time;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
    void OnCollisionEnter(Collision other)
    {
        if (Vector3.Angle(other.contacts[0].normal, Vector3.up) < 10)
            is_jumping = false;
    }
}
