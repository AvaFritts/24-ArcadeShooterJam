using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Script_GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int misses;
    public int shots;

    public int points;

    GameObject player;
    
    public GameObject[] enemies;
    public float spawnRate;
    float timer;
    float totalTime1;
    float totalTime2;
    float totalTime3;
    float totalTime4;
    //I know this is gross but honestly do it yourself if you have an issue

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        timer = 0;
        misses = 0;
        shots = 0;
        points = 0;
        totalTime1 = 0;
        totalTime2 = 0;
        totalTime3 = 0;
        totalTime4 = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime1 += Time.deltaTime;
        timer += Time.deltaTime;

        if(spawnRate > 3){
            spawnRate = 6-totalTime1*.1f; //dont really know uhh, what this is, but its good
        }
        else if(spawnRate > 2){
            totalTime2 += Time.deltaTime;
            spawnRate = 3-totalTime2*.033333333f;
            //idk its late and this is weird but it should take the same amount of time to get to 2
            //from 3 as the above took to get to 3 from 6
        }
        else if(spawnRate > 1){
            totalTime3 += Time.deltaTime;
            spawnRate = 2-totalTime3*.033333333f;
        }
        else if(spawnRate > .25f){
            totalTime4 += Time.deltaTime;
            spawnRate = 1-totalTime4*.015f;
        }


        if(timer >= spawnRate){
            int type = Random.Range(1, 101);
            GameObject newEnemy;
            if(type <= 10) newEnemy = Instantiate(enemies[0]);
            else if(type <= 30) newEnemy = Instantiate(enemies[1]);
            else if(type <= 60) newEnemy = Instantiate(enemies[2]);
            else newEnemy = Instantiate(enemies[3]);
            newEnemy.transform.position = new Vector3(10f, Random.Range(-2f, 5f), 0f);
            timer = 0;
        }
    }



    public void dead(){
        Debug.Log("Player Died");
        Time.timeScale = 0;
    }
}
