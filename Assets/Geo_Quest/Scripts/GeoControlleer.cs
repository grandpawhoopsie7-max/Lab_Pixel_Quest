using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoControlleer : MonoBehaviour {
    public int counter = 0;
    
    // Start is called before the first frame update
    public void Start() {
        counter = 1;
        Debug.Log("hasdasd");
    }

    // Update is called once per frame
    void Update() 
    {
       if (Input.GetKeyDown(KeyCode.W))
      
        transform.position += new Vector3(0, 1, 0);
    }

}