using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 8f;
    [Tooltip("In m")] [SerializeField] float rangeX = 7f;
    [Tooltip("In m")] [SerializeField] float rangeY = 5f;

    [Header("Screen Position Base")]
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float positionYawFactor = 2.5f;

    [Header("Control Throw Base")]
    [SerializeField] float controlThrowPitchFactor = -30f;
    [SerializeField] float controlThrowRollFactor = -20f;

    [Header("Wepons")]
    [SerializeField] GameObject[] guns;

    float xThrow, yThrow;

    bool isControlEnabled = true;

    
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            Fire();
        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

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

    private void Fire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            foreach(GameObject gun in guns)
            {
                gun.SetActive(true);
            }

        }
        else
        {
            foreach(GameObject gun in guns)
            {
                gun.SetActive(false);
            }
        }
    }
}
