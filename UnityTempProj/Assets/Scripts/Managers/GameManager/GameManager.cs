using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    #region GameManager Singleton
    static private GameManager gm; //refence GameManager
    static public GameManager GM { get { return gm; } } //public access to read only gm 

    //Check to make sure only one gm of the GameManager is in the scene
    void CheckGameManagerIsInScene()
    {

        //Check if instnace is null
        if (gm == null)
        {
            gm = this; //set gm to this gm of the game object
            Debug.Log(gm);
        }
        else //else if gm is not null a Game Manager must already exsist
        {
            Destroy(this.gameObject); //In this case you need to delete this gm
        }
        DontDestroyOnLoad(this); //Do not delete the GameManager when scenes load
        Debug.Log(gm);
    }//end CheckGameManagerIsInScene()
    #endregion


    public string startScene;
    public string levelScene;
    public string deadScene;

    public int score;
    public float accuracy;

    string currentSceneName;


    void Awake(){
        CheckGameManagerIsInScene();

        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame(){

    }

    public void dead(){
        Invoke("deaded", 2f);
    }

    public void alive(){
        SceneManager.LoadSceneAsync(levelScene);
    }

    private void deaded(){
        SceneManager.LoadSceneAsync(deadScene);
    }

}
