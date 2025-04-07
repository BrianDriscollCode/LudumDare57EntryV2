using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds;  // Array of all the back and foregrounds
    public float[] parallaxScales;   // Proportion of camera movement to move the backgrounds
    public float smoothing = 1f;     // How smooth the parallax is. > 0
    public float backgroundWidth = 10f;  // Width of the background to determine when it moves out of view

    private Transform cam;           // Reference to the main camera's transform
    private Vector3 previousCamPos;  // Position of the camera in the previous frame

    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;

        // Assign parallax scales based on Z positions (or manual values)
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calculate the parallax effect based on the camera's movement
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Invert the parallax direction by multiplying by -1 to move the background opposite to the camera's movement
            parallax = -parallax;

            // Calculate the target position of the background
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // If the background has moved out of view, reset its position
            if (Mathf.Abs(backgrounds[i].position.x - cam.position.x) >= backgroundWidth)
            {
                backgroundTargetPosX = backgrounds[i].position.x + Mathf.Sign(parallax) * backgroundWidth;
            }

            // Create the target position with the same y and z positions
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Smoothly transition to the target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Update the previous camera position for the next frame
        previousCamPos = cam.position;
    }
}


