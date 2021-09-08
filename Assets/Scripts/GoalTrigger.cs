using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GoalTrigger : MonoBehaviour
{
    public List<Transform> teleports;

    private void OnTriggerEnter(Collider other)
    {
        var number = new Random().Next(teleports.Count);
        var teleport = teleports[number];
        var vector = new Vector3(-4f, 0, -4f);
        other.transform.position = teleport.position - vector;
    }

    private void OnTriggerExit(Collider other)
    {
        var obstacle = GameObject.Find("Obsacle");
        Instantiate(obstacle, other.transform.position + Vector3.forward, Quaternion.identity);
        
        if (Utils.HasComponent<TextMesh>(other.gameObject)) return;
        
        var mesh = other.gameObject.AddComponent<TextMesh>();
        mesh.fontSize = 20;
        mesh.offsetZ = 10f;
        mesh.text = "You found a portal";
        Destroy(mesh, 2f);
    }
}
