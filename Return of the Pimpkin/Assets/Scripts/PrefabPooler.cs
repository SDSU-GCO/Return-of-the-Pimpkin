using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PrefabPooler : MonoBehaviour
{
#pragma warning disable CS6049
#pragma warning disable CS0414
    [SerializeField]
    int GUID = 0;
    [SerializeField]
    bool GUIDSet = false;

#pragma warning restore CS6049
#pragma warning restore CS0414
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start: " + this + " " + System.DateTime.UtcNow);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: " + this + " " + System.DateTime.UtcNow);
    }
}
