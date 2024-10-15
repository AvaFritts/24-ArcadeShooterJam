using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ShardController : Enemy
{
    // Start is called before the first frame update

    void Start()
    {
        transform.GetChild(0).transform.Rotate(new Vector3(0f, 0f, Random.Range(0, 3)*90f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
            addPoints();
        }
        if(other.tag == "Player"){
            Object.Destroy(this.gameObject);
            HurtPlayer();
        }
        if(other.tag == "Deleter"){
            Debug.Log("Hit Deleter, removing object");
            Object.Destroy(this.gameObject);
        }
    }
}
