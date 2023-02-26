using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float startingWarmth;
    public float startingDifficulty;
    public float diffIncPerSec;
    public float warmthIncPerSec;
    public int numEnemyPrefabs; //need so we can initialize list with correct size

    private float difficulty;

    private float warmth;
    private float baseWarmth;
    private float artificialWarmth;
    //Artificial warmth is the warmth generated by user actions such as processing coal or explosions
    //There is a incrementer function for warmth

    //Enemy spawning data structures
    private float gameStartTime;
    private float lastSpawnTime;
    private Enemy[] enemyList;
    private float[] chanceVals;
    private bool gameStarted = false;

    //UI manager object
    private PlacementUIManager placeUIMan;
    private GlobalWarmingManager globalWarmingManager;
    private ArtichokeManager artichokeManager;
    private ScoreManager scoreManager;
    [SerializeField] private Canvas startScreen;
    [SerializeField] private Canvas pauseCanvas;
    private bool paused = false;

    //Planet
    private Planet planet;
    //Prefab
    private Planet ppf;

    

    // Start is called before the first frame update
    void Start()
    {
        this.baseWarmth = this.startingWarmth;
        this.difficulty = this.startingDifficulty;
        this.enemyList = new Enemy[numEnemyPrefabs];
        this.chanceVals = new float[numEnemyPrefabs];
        this.ppf = Resources.Load<Planet>("Prefabs/Planet/Planet");
        placeUIMan = FindObjectOfType<PlacementUIManager>();
        globalWarmingManager = FindObjectOfType<GlobalWarmingManager>();
        artichokeManager = FindObjectOfType<ArtichokeManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        placeUIMan.gameObject.SetActive(false);
        globalWarmingManager.gameObject.SetActive(false);
        artichokeManager.gameObject.SetActive(false);
        scoreManager.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);

        FindObjectOfType<AudioManager>().PlayMusic(0);


        //Initializing enemy prefab list stuff
        //TO-DO when we make enemy prefabs

        enemyList[0] = Resources.Load<Enemy>("Prefabs/Enemies/BasicEnemy");

        float chanceAccum = 0; //associating value rand needs to hit to spawn this enemy
        for(int i = 0; i<numEnemyPrefabs; i++)
        {
            chanceAccum += enemyList[i].GetComponent<Enemy>().spawnChance;
            this.chanceVals[i] = chanceAccum;
            
            Debug.Log("Chanceaccum:" + chanceAccum);
        }
        //if for some reason our chances add up to over 1, this will "normalize"
        for(int i = 0; i<numEnemyPrefabs; i++)
        {
            this.chanceVals[i] /= chanceAccum;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
                //Initializing planet
                this.planet = Instantiate(ppf);
                
                placeUIMan.gameObject.SetActive(true);
                globalWarmingManager.gameObject.SetActive(true);
                artichokeManager.gameObject.SetActive(true);
                scoreManager.gameObject.SetActive(true);
                startScreen.gameObject.SetActive(false);

                //Initializing game time values
                this.gameStartTime = Time.time;
                this.lastSpawnTime = this.gameStartTime;
            }
        }
        else
        {
            difficultyHandler();
            spawnHandler();
            warmthHandler();
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
        }
        if(paused) {
            pauseCanvas.gameObject.SetActive(true );
            Time.timeScale = 0f;
        }
        else {
            pauseCanvas.gameObject.SetActive(false );
            Time.timeScale = 1f;
        }
        
    }

    void difficultyHandler()
    {
        if (this.difficulty > 1)
        {
            this.difficulty = 1;
        }
        else
        {
            this.difficulty = diffIncPerSec * (Time.time - this.gameStartTime);
        }

        if (this.difficulty > .5f) {
            FindObjectOfType<AudioManager>().PlayMusic(1);
        }
        else {
            FindObjectOfType<AudioManager>().PlayMusic(0);
        }
    }

    void spawnHandler()
    {
        float timeSinceSpawn = Time.time - this.lastSpawnTime;
        if(timeSinceSpawn > difficultyFunction(difficulty))
        {
            lastSpawnTime = Time.time;
            float chance = Random.value;
            for(int i = 0; i < numEnemyPrefabs; i++)
            {
                //Debug.Log("Current chance: " + chanceVals[i]);
                if(chanceVals[i] > chance)
                {
                    Enemy newEnemy = Instantiate(enemyList[i]);
                    newEnemy.setPosPol(1f, Random.Range(0, 360));
                    //newEnemy.transform.Rotate(new Vector3(0, 0, 0));
                    float sca = planet.radius / planet.numPlots * 3;
                    newEnemy.transform.localScale = newEnemy.transform.localScale * sca;
                    break;
                }
            }
        }
        
        
    }
    
    //this returns the delay in between enemy spawns given the difficulty
    float difficultyFunction(float d)
    {
        return 1f / (d + 0.1f) + 10;
    }

    void warmthHandler()
    {
        this.baseWarmth += warmthIncPerSec;
        this.warmth = this.baseWarmth + this.artificialWarmth;
        if (warmth > 1)
        {
            warmth = 1;
        }
        else if(warmth < 0)
        {
            warmth = 0;
        }
        globalWarmingManager.SetGlobalWarming(warmth);
    }

    public void changeWarmth(float warm)
    {
        artificialWarmth += warm;
    }

    public float getWarmth()
    {
        return warmth;
    }
}