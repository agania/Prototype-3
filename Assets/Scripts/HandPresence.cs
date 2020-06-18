﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedContoller;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    private float jumpForce = 22.0f;
    private float gravityModifier = 2.0f;
    private GameObject player;
    private Rigidbody playerRB;


    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    public void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedContoller = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("nie znaleziono wlasciwego modelu kontrolera");
                spawnedContoller = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (showController)
            {
                spawnedHandModel.SetActive(false);
                spawnedContoller.SetActive(true);
            }
            else
            {
                spawnedHandModel.SetActive(true);
                spawnedContoller.SetActive(false);
                UpdateHandAnimation();
            }
        }




        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue &&  player.transform.position.y < 0.05f )
        {
            Debug.Log("Nacisnieto glowny przycisk");
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        /*       targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
               if (triggerValue > 0.01f)
                   Debug.Log("Nacinieto spust: " + triggerValue);

               targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
               if (primary2DAxisValue != Vector2.zero)
                   Debug.Log("Glowny joystick: " + primary2DAxisValue);*/
    }

}