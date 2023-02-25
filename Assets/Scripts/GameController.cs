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

    //Planet
    private Planet planet;

    // Start is called before the first frame update
    void Start()
    {
        this.warmth = this.startingWarmth;
        this.difficulty = this.startingDifficulty;
        this.gameStartTime = Time.time;
        this.enemyList = new Enemy[numEnemyPrefabs];
        this.chanceVals = new float[numEnemyPrefabs];


        //Initializing enemy prefab list stuff
        //TO-DO when we make enemy prefabs
        //enemyList[0] = Resources.Load<Enemy>("Enemies/x");

        float chanceAccum = 0; //associating value rand needs to hit to spawn this enemy
        for(int i = 0; i<numEnemyPrefabs; i++)
        {
            this.chanceVals[i] = chanceAccum;
            chanceAccum += enemyList[i].spawnChance;
        }
        //if for some reason our chances add up to over 1, this will "normalize"
        for(int i = 0; i<numEnemyPrefabs; i++)
        {
            this.chanceVals[i] /= chanceAccum;
        }

        //Initializing planet
        this.planet = Instantiate(Resources.Load<Planet>("Planet/Planet"));
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        difficultyHandler();
        spawnHandler();
        warmthHandler();
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
                if(chanceVals[i] > chance)
                {
                    Enemy newEnemy = Instantiate(enemyList[i]);
                    newEnemy.setPosPol(1f, Random.Range(0, 360));
                    break;
                }
            }
        }
        
        
    }
    
    //this returns the delay in between enemy spawns given the difficulty
    float difficultyFunction(float d)
    {
        return 1f / d;
    }

    void warmthHandler()
    {
        this.baseWarmth = this.difficulty;
        this.warmth = this.baseWarmth + this.artificialWarmth;
        if (warmth > 1)
        {
            warmth = 1;
        }
        else if(warmth < 0)
        {
            warmth = 0;
        }
    }

    void changeWarmth(float warm)
    {
        artificialWarmth += warm;
    }

    public float getWarmth()
    {
        return warmth;
    }
}
