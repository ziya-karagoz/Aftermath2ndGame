﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject newCube;
    public GameObject connectedBody;

    Cube cube;

    FacesOccupationController facesOccupationController;

    private void Awake()
    {
        cube = GetComponent<Cube>();
        facesOccupationController = GetComponent<FacesOccupationController>();

        SetConnectedBody();
    }

    private void Update()
    {
        SpawnNextCube();

    }



    /// <summary>
    /// This method is for spawning new cube to the scene with current cube features. 
    /// </summary>
    public void SpawnNextCube()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {  
            cube.isInCurrentCube = false;
            ClearOccupationStates();
            Generate();
            DisableCurrentCubeFeatures();
        }
    }

    /// <summary>
    /// This method is for to disable the current cube features of previous cubes, due to make them do not act like current cube.
    /// </summary>
    private void DisableCurrentCubeFeatures()
    {
        cube.enabled = false;
        facesOccupationController.enabled = false;
        this.enabled = false;
    }


    /// <summary>
    /// This method is for instantiate new cube
    /// </summary>
    private void Generate()
    {
        newCube = Instantiate(this.gameObject, facesOccupationController.transparentCube.transform.position, facesOccupationController.transparentCube.transform.rotation);

    }


    /// <summary>
    /// This method is for clearing faces occpation states of cube due to generate next cube properly.
    /// </summary>
    private void ClearOccupationStates()
    {
        for (int i = 0; i < facesOccupationController.isOccupied.Length; i++)
        {
            facesOccupationController.isOccupied[i] = false;
        }
    }

    private void SetConnectedBody()
    {
        
        gameObject.GetComponent<ConfigurableJoint>().connectedBody = connectedBody.GetComponent<Rigidbody>();
        gameObject.transform.parent = connectedBody.transform;
    }


}
