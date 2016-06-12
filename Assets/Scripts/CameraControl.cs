using UnityEngine;
using System.Collections;

using UnityEngine.VR.WSA.Input;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour
{
    private GestureRecognizer gr;
    public Vector3[] cameraPositions;
    public Vector3[] cameraRotations;
    private int index = 0;

    private void Start()
    {
        gr = new GestureRecognizer();

        gr.TappedEvent += OnTap;

        gr.StartCapturingGestures();
    }

    private void OnTap(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if (index >= cameraPositions.Length) index = 0;
        transform.position = cameraPositions[index];
        transform.position = cameraRotations[index++];
    }
}
