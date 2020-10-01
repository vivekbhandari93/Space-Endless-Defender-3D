using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float speed = 8f;
    [Tooltip("In m")] [SerializeField] float rangeX = 7f;
    [Tooltip("In m")] [SerializeField] float rangeY = 5f;

    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float controlThrowPitchFactor = -30f;

    [SerializeField] float positionYawFactor = 2.5f;
    [SerializeField] float controlThrowRollFactor = -20f;
    

    float xThrow, yThrow;

    
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawPosX = transform.localPosition.x + xOffset;
        float rawPosY = transform.localPosition.y + yOffset;

        float clampRawPosX = Mathf.Clamp(rawPosX, -rangeX, rangeX);
        float clampRawPosY = Mathf.Clamp(rawPosY, -rangeY, rangeY);

        transform.localPosition = new Vector3(clampRawPosX, clampRawPosY, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlThrowPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlThrowRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
