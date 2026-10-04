using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float xRotate = 0f;
    

    public Camera playerCam;
    public float xSense = 30f;
    public float ySense = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY= input.y;
        //cam rotation based on inputs
        xRotate -= (mouseY * Time.deltaTime) * ySense;
        xRotate = Mathf.Clamp(xRotate, -80f, 80f);

        playerCam.transform.localRotation = Quaternion.Euler(xRotate,0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSense);
    }
}
