/*
See the Unity Tutorial to know how to use this script: https://youtu.be/O2Pg8e2xwzg

Developed by Lumidi - Alex Zuniga: https://twitter.com/LumidiDev
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class SimpleCameraShakeInCinemachine : MonoBehaviour
{

    [SerializeField] float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    [SerializeField] float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    [SerializeField] float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter
    [SerializeField] float forceMultAmplitude = 0.2f;
    [SerializeField] float forceMultFrequency = 0.05f;

    // Cinemachine Shake
    [SerializeField] CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    PlayerController playerController;

    private float ShakeElapsedTime = 0f;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Use this for initialization
    void Start()
    {
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
        {
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
            playerController.OnStrike += Shake;
        }
    }

    private void Shake(int _)
    {
        ShakeElapsedTime = ShakeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // If the Cinemachine componet is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeElapsedTime > 0)
            {
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude + playerController.forceMag * forceMultAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency + playerController.forceMag * forceMultFrequency;

                // Update Shake Timer
                ShakeElapsedTime -= Time.fixedUnscaledDeltaTime;
            }
            else
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }
}
