using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - objectToFollow.position;
    }

    void Update()
    {
        transform.position = objectToFollow.position + offset;
    }
}
