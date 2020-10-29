using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionPlayerController : MonoBehaviour
{
    public enum PlayerType { PlayerL, PlayerR};

    public PlayerType player;
    public float movSpeed = 5;

    public int correctAbductionPoints;
    public int wrongAbductionPoints;

    private KeyCode up, down, left, right;
    private int score = 0;

    private Rect scoreRectPos;


	// Use this for initialization
	void Start ()
    {
        //Assign correct KeyCode according to Player enum
        up = player == PlayerType.PlayerL ? KeyCode.W : KeyCode.UpArrow;
        down = player == PlayerType.PlayerL ? KeyCode.S : KeyCode.DownArrow;
        left = player == PlayerType.PlayerL ? KeyCode.A : KeyCode.LeftArrow;
        right = player == PlayerType.PlayerL ? KeyCode.D : KeyCode.RightArrow;

        scoreRectPos = player == PlayerType.PlayerL ? new Rect(10, 10, 80, 20) : new Rect(Screen.width - 90, 10, 150, 20);

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(up))
            transform.Translate(transform.forward * movSpeed * Time.deltaTime);

        if (Input.GetKey(down))
            transform.Translate(-transform.forward * movSpeed * Time.deltaTime);

        if (Input.GetKey(left))
            transform.Translate(-transform.right * movSpeed * Time.deltaTime);

        if (Input.GetKey(right))
            transform.Translate(transform.right * movSpeed * Time.deltaTime);
    }

    private void OnGUI()
    {
        GUI.Label(scoreRectPos, "Player: " + score);
    }

    private void OnTriggerEnter(Collider other)
    {
        AbductionEnemy e = other.transform.GetComponent<AbductionEnemy>();
        if (e != null)
        {
            e.Abduct();
            if (e.enemyOfPlayer == player)
                score += correctAbductionPoints;
            else
                score += wrongAbductionPoints;

        }
           
    }
}
