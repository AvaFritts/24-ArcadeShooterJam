using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Script_BottleController : Enemy
{
    // Start is called before the first frame update

    float startY;
    float bobOffset;

    public GameObject shards;

    void Start()
    {
        startY = transform.position.y;
        bobOffset = 0f;//UnityEngine.Random.Range(math.PI/2, 3*math.PI/2);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(transform.position.x/2 + bobOffset)*.75f + startY, 0);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            createShards();
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

    private void createShards(){
        int num = UnityEngine.Random.Range(2,4);

        for (int i = 0; i < num; i++)
        {
            Instantiate(shards, (Vector3)UnityEngine.Random.insideUnitCircle*1.25f + transform.position + Vector3.right*2, Quaternion.identity);
        }
    }
}
