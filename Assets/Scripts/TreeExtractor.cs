using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
 
 
[ExecuteInEditMode]
public class TreeExtractor : MonoBehaviour
{
    public bool populateTrees;
    public Terrain terrain;
    public List<GameObject> trees;
 
    private void Update()
    {
        if (populateTrees == true)
        {
            Convert();
            populateTrees = false;
        }
    }
 
    public void Convert()
    {
        GameObject allTrees = new GameObject("AllTrees"); //All trees will be placed under this gameobject 
        allTrees.transform.parent = transform; //make allTrees a parent of this transform
 
        TerrainData data = terrain.terrainData;
        float width = data.size.x;
        float height = data.size.z;
        float y = data.size.y;
        TreePrototype[] treeProtoypes =  terrain.terrainData.treePrototypes; // get tree prototypes on the terrain
        foreach (TreePrototype treeProtoype in treeProtoypes) //extract the tree prefabs into the Gameobject list
        {
            trees.Add(treeProtoype.prefab.gameObject); 
        }
 
        //place the trees
        foreach (TreeInstance tree in data.treeInstances)
        {
             
            Vector3 position = new Vector3(tree.position.x * width, tree.position.y * y, tree.position.z * height);
            Vector3 scale = new Vector3(tree.widthScale, tree.heightScale, tree.widthScale);
            GameObject treeToBePlaced = trees[tree.prototypeIndex];
            treeToBePlaced.transform.localScale = scale;
            Instantiate(treeToBePlaced, position, Quaternion.identity, allTrees.transform);
        }
    }
}