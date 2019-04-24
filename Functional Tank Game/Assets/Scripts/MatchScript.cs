using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchScript : MonoBehaviour
{
    /* Match timer variables */
    public float matchTime;
    private int displayTime;
    public Text timerText;

    /* player1 timer variables */
    public float p1Time;
    public int p1DisplayTime;
    public Text Player1Timer;

    /* player2 timer variables */
    public float p2Time;
    public int p2DisplayTime;
    public Text Player2Timer;

    /* Start Time setup */
    public float startTime;
    private float startTrigger = 0f;

    /* Start timer dispaly */
    public float startTimer;
    public int startTimerDisplay;
    public Text startTimerDis;

    public PlayerTank1 player1;
    public PlayerTank2 player2;
    public ProjectileCollision bullet;

    public Text winText;

    public float disableTimeText;
    public float returnToTitle;

    public Animator animate;

    public CameraPan camera1;

    // Start is called before the first frame update
    void Start()
    {
        /* Player Object */
        player1 = GameObject.FindWithTag("PlayerTank1").GetComponent<PlayerTank1>();
        player2 = GameObject.FindWithTag("PlayerTank2").GetComponent<PlayerTank2>();

        /* Camera Object */
        camera1 = GameObject.FindWithTag("MainCamera").GetComponent<CameraPan>();

        /* Match Timer */
        displayTime = (int)matchTime;
        timerText.text = displayTime.ToString();

        /* Player 1 Timer */
        p1Time = player1.turnTime;
        p1DisplayTime = (int)p1Time;
        Player1Timer.text = p1DisplayTime.ToString();

        /* Player 2 Timer */
        p2Time = player2.turnTime;
        p2DisplayTime = (int)p2Time;
        Player2Timer.text = p2DisplayTime.ToString();

        /* Start timer */
        startTimer = startTime;
        //startTimerDisplay = (int)startTimer;
        //startTimerDis.text = startTimerDisplay.ToString();

    }

    //----------------------------------------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        /* This is detecting if there is a bullet object in the game at the moment */
        //bullet = GameObject.FindWithTag("Bullet").GetComponent<ProjectileCollision>();

        //-------------------------------------------------------------------------------------------------------------------

        /* Updates Time */
        startTrigger += Time.deltaTime;
        startTimer -= Time.deltaTime;
        
        //-------------------------------------------------------------------------------------------------------------------
        
        /* Updates the text before the match */
        if(startTimer > 1)
        {
            startTimerDis.text = "Ready!";
        }

        if(startTimer <= 1 && startTimer >= -1)
        {
            startTimerDis.text = "Go!";         
        }
        if(startTimer < 0)
        {
            startTimerDis.text = "";
        }

        //-------------------------------------------------------------------------------------------------------------------

        /* Match Time Updated for both players and the time */
        if (startTrigger >= startTime)
        {
            if (player1.currentHealth > 0 && player2.currentHealth > 0)
            {
                /* Turn Dictator */
                //turnDetermine(player1, player2);

                /* Start Match Timer */
                matchTime -= Time.deltaTime;
                displayTime = (int)matchTime;
                timerText.text = displayTime.ToString();
                if (matchTime <= 0)
                    timerText.text = "0";

                /* Player 1 timer update */
                if (player1.turnCheck == true && camera1.cameraCheck1 == true)
                {
                    p1Time -= Time.deltaTime;
                    p1DisplayTime = (int)p1Time;
                    Player1Timer.text = p1DisplayTime.ToString();
                    if (p1Time <= 0)
                        Player1Timer.text = "0";
                }

                /* Player 2 timer update */
                if (player2.turnCheck == true && camera1.cameraCheck2 == true)
                {
                    p2Time -= Time.deltaTime;
                    p2DisplayTime = (int)p2Time;
                    Player2Timer.text = p2DisplayTime.ToString();
                    if (p2Time <= 0)
                        Player2Timer.text = "0";
                }

                /* Setting the fired projectile check to false for both objects */
                //player1.firedProjectile = false;
                //player2.firedProjectile = false;


                if (matchTime < 0)
                {
                    //player1.enabled = false;
                    //player2.enabled = false;
                    timerText.text = "0";
                    if (matchTime <= disableTimeText)
                    {
                        if (player1.currentHealth > player2.currentHealth)
                        {
                            winText.text = "Player 1 Wins!";
                        }
                        else if (player1.currentHealth < player2.currentHealth)
                        {
                            winText.text = "Player 2 Wins!";
                        }
                        else if (player1.currentHealth == player2.currentHealth)
                        {
                            winText.text = "Draw!";
                        }
                    }
                    else
                    {
                        winText.text = "Time!";
                    }
                }

            }
            else
            {
                //player1.enabled = false;
                //player2.enabled = false;
                if (player1.currentHealth <= 0 && player2.currentHealth > 0)
                {
                    winText.text = "Player 2 Wins!";
                }
                else if (player2.currentHealth <= 0 && player1.currentHealth > 0)
                {
                    winText.text = "Player 1 Wins!";
                }
                else if (player1.currentHealth <= 0 && player2.currentHealth <= 0)
                {
                    winText.text = "Draw!";
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------

        // goes to start screen after match
        if (matchTime <= (returnToTitle))
        {
            SceneManager.LoadScene(0);
        }

        //-------------------------------------------------------------------------------------------------------------------

        /* Updates Player Turn */
        if (player1.turnCheck == false && player2.turnCheck == false && matchTime > 0)
        {
            player1.turnCheck = true;
        }

        if (player1.turnCheck == true && matchTime > 0 && camera1.cameraCheck1 == true)
        {
            p2Time = player2.turnTime;
            player2.turnCheck = false;
            player2.firedProjectile = false;
            if (player1.firedProjectile == true)
            {
                player1.turnCheck = false;
                player2.turnCheck = true;
            }
            else if (p1Time <= 0)
            {
                player1.turnCheck = false;
                player2.turnCheck = true;
            }
        }

        if (player2.turnCheck == true && matchTime > 0 && camera1.cameraCheck2 == true)
        {
            p1Time = player1.turnTime;
            player1.turnCheck = false;
            player1.firedProjectile = false;
            if (player2.firedProjectile == true)
            {
                player1.turnCheck = true;
                player2.turnCheck = false;
            }
            else if (p2Time <= 0)
            {
                player1.turnCheck = true;
                player2.turnCheck = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------

        if (matchTime <= 0)
        {
            player1.turnCheck = false;
            player2.turnCheck = false;
        }

    } // end update

    /*
    void turnDetermine(PlayerTank1 player1, PlayerTank2 player2)
    {
        if (player1.turnCheck == false && player2.turnCheck == false)
        {
            player1.turnCheck = true;
        }
        else if (player1.turnCheck == true)
        {
            player2.turnCheck = false;
            if (player1.firedProjectile == true)
            {
                player1.turnCheck = false;
                player2.turnCheck = true;
            }
            else if (player1.movementComplete == true)
            {
                player1.turnCheck = false;
                player2.turnCheck = true;
            }
        }
        else if (player2.turnCheck == true)
        {
            player1.turnCheck = false;
            if (player2.firedProjectile == true)
            {
                player1.turnCheck = true;
                player2.turnCheck = false;
            }
            else if (player2.movementComplete == true)
            {
                player1.turnCheck = true;
                player2.turnCheck = false;
            }
        }
        else if (matchTime == 0)
        {
            player1.turnCheck = false;
            player2.turnCheck = false;
        }

    } // end turnDetermine
    */
} // end class
