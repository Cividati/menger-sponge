using UnityEngine;
using System.Collections.Generic;
using System;

public class MengerSponge : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    List<GameObject> cubes = new List<GameObject>();
    public float size = 300f;


    void Start() {
        GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        go.transform.localScale = new Vector3(size, size, size);
        go.GetComponent<Cube>().size = size;
        cubes.Add(go);
    }

    void Update() {
            
        // if on mouse click
        if (Input.GetMouseButtonDown(0)){
            List<GameObject> newCubes = Split(cubes);
            foreach(var go in cubes) {
                Destroy(go);
            }
            cubes = newCubes;
            print(cubes.Count);
        }
    }

    List<GameObject> Split(List<GameObject> cubes) {
        List<GameObject> subCubes = new List<GameObject>();
        foreach(var cube in cubes){
            float size = cube.GetComponent<Cube>().size;
            for (int x =-1; x < 2; x++){
                for (int y =-1; y<2; y++){
                    for(int z=-1; z<2; z++){
                        float xx = x * (size / 3f);
                        float yy = y * (size / 3f);
                        float zz = z * (size / 3f);

                        Vector3 cubePos = new Vector3(xx, yy, zz) + cube.transform.position;

                        int sum = Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z);
                        
                        if (sum > 1){
                            GameObject copy = Instantiate(cube, cubePos, Quaternion.identity);
                            copy.GetComponent<Cube>().size = size / 3f;
                            copy.transform.localScale = new Vector3(size / 3f, size / 3f, size / 3f);

                            subCubes.Add(copy);
                        }
                    }
                }
            }
        }
        return subCubes;
    }

    public void RemoveObjectFromList(GameObject o) {
        if(cubes.Contains(o)){
            cubes.Remove(o);
            //Destroy(o);
            }
            else return ;
        print("cubes count: "+cubes.Count.ToString());
    }
}
