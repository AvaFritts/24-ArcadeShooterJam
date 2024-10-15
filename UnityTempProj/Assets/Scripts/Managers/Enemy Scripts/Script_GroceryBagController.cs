using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GroceryBagController : Enemy
{
    // Start is called before the first frame update
    float startY;

    int health = 3;

    public GameObject cup;
    public GameObject sixRing;

    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(transform.position.x/2)/3+startY, 0);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            health--;
            int spawn = Random.Range(1, 3);
            if(spawn == 1){
                Instantiate(cup, transform.position + Vector3.left, Quaternion.identity);
            }
            else Instantiate(sixRing, transform.position + Vector3.left, Quaternion.identity);
            if(health<=0){
                addPoints();
                Object.Destroy(this.gameObject);
            }
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
