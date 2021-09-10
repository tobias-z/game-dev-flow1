using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    
    public float detectObjectRadius = 15f;

    private List<GameObject> triggerObjects;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + other.tag);
        Renderer triggerObject = other.GetComponent<Renderer>();
        if (other.tag == "Tree")
        {
            triggerObject.material.color = Color.red;
            triggerObjects.Add(other.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        triggerObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerObjects.Count > 0)
        {
            foreach (var triggerObject in triggerObjects)
            {
                if (Vector3.Distance(triggerObject.transform.position, transform.position) >= detectObjectRadius)
                {
                    Renderer renderer = triggerObject.GetComponent<Renderer>();
                    renderer.material.color = Color.black;
                    Debug.Log("Color change" + triggerObject.tag);
                    triggerObjects.Remove(triggerObject);
                    Debug.Log("Removed" + triggerObject.tag);
                }
            }
        }

    }
}
