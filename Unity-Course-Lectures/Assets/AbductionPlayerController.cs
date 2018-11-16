using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionPlayerController : MonoBehaviour
{
    public enum PlayerType { Player0, Player1};

    public PlayerType player;
    public float movSpeed = 5;

    private KeyCode up, down, left, right;


	// Use this for initialization
	void Start ()
    {
        up = player == PlayerType.Player0 ? KeyCode.W : KeyCode.UpArrow;
        down = player == PlayerType.Player0 ? KeyCode.S : KeyCode.DownArrow;
        left = player == PlayerType.Player0 ? KeyCode.A : KeyCode.LeftArrow;
        right = player == PlayerType.Player0 ? KeyCode.D : KeyCode.RightArrow;

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

    private void OnTriggerEnter(Collider other)
    {
        Enemy e = other.transform.GetComponent<Enemy>();
        if (e != null)
            e.Abduct();
    }
}
