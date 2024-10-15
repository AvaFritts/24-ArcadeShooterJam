using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Background_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;

        if(transform.position.x <= -19) transform.position = new Vector3(19f, 1f, 10f);
    }
}
