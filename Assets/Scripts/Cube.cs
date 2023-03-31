using UnityEngine;

public class Cube : MonoBehaviour
{
    
    [System.NonSerialized]
    public float size = 1f;
    public int id;

    void OnDestroy(){
        GameObject go = GameObject.Find("_MengerSponge");
        go.GetComponent<MengerSponge>().RemoveObjectFromList(gameObject);

    }

}

