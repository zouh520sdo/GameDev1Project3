using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{

    //These are the individual meters associated with the AI
    //Hunger: Always increases, goes down by static amounts
        //When at a full meter, go to lose state
    //Boredom: Increases while bored, which is defined as hasn't been played with in a short time period
        //When at a high boredom, other meters increase at a faster rate
    //Danger: Increases while alone, which is defined as not being near the player. Goes down otherwise.
        //When at full danger, go to lose state
    //Tiredness: Increases constantly, also tied to a sleeping state
        //When at full sleep, must go to child and take them to their bed. Meters will rapidly increase
        //during this time.
        //While asleep, no meters increase

    //Personality concept?
    //
    //What this script needs:
    /*
     * Control of meters for individual children 
     * Way to decide movement patterns for children
     * Possibly children actions
     */

    public int boredom = 0;
    public int hunger = 0;
    public int danger = 0;
    public int tired = 0;

    int lastBored = 0;

    public int timeToWakeup = 60;
    public int maxBoredom = 60;
    public int maxHunger = 180;
    public int maxDanger = 60;

    bool isBored = false;
    bool isAlone = false;
    bool isAsleep = false;
    bool isTired = false;

    public GameObject playerRef;

    // Update is called once per frame
    void Update()
    {


    }
}
