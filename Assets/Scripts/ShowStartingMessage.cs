using UnityEngine;

public class ShowStartingMessage : MonoBehaviour
{
    public float destroyTime = 4f;
    
    private void Start()
    {
        var mesh = GetComponent<TextMesh>();
        mesh.text = "So many finish lines!";
        Destroy(gameObject, destroyTime);
    }

}
