using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public float detectObjectRadius = 15f;


    private Dictionary<Renderer, Vector3> _trees;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Tree")) return;
        var curRenderer = other.GetComponent<Renderer>();
        var vector3 = curRenderer.transform.localScale;

        if (_trees.ContainsKey(curRenderer)) return;

        _trees.Add(curRenderer, vector3);

        curRenderer.transform.localScale = new Vector3(0, 0, 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        _trees = new Dictionary<Renderer, Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_trees.Count <= 0) return;
        foreach (var triggerObject in _trees.Where(triggerObject => Vector3.Distance(triggerObject.Key.transform.position, transform.position) >= detectObjectRadius))
        {
            triggerObject.Key.transform.localScale = triggerObject.Value;
        }

    }
}
