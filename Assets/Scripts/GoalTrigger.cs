using UnityEngine;
using Random = System.Random;

public class GoalTrigger : MonoBehaviour
{
    private GameObject[] _teleports;
    private GameObject _obstacle;

    private void Awake()
    {
        _obstacle = GameObject.Find("Obsacle");
        _teleports = GameObject.FindGameObjectsWithTag("teleport");
    }

    private void OnTriggerEnter(Collider other)
    {
        var number = new Random().Next(_teleports.Length);
        var teleport = _teleports[number];
        var vector = new Vector3(-4f, 0, -4f);
        other.transform.position = teleport.transform.position - vector;
    }

    private void OnTriggerExit(Collider other)
    {
        Instantiate(_obstacle, other.transform.position + Vector3.forward, Quaternion.identity);

        if (other.gameObject.HasComponent<TextMesh>()) return;

        ShowMessage(other);
    }

    private static void ShowMessage(Component other)
    {
        var mesh = other.gameObject.AddComponent<TextMesh>();
        mesh.fontSize = 20;
        mesh.offsetZ = 10f;
        mesh.text = "You found a portal";
        Destroy(mesh, 2f);
    }
}