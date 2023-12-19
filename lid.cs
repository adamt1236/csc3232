using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("delete lid");
            gameObject.SetActive(false);
        }
    }
}
