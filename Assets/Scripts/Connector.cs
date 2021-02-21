using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] Player[] playerArr = new Player[4];
    [SerializeField] Dictionary<string, Player> playerList = new Dictionary<string, Player>();
    [DllImport("__Internal")] private static extern string[,] GetInput();

    bool idCreated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
    }

    void GetPlayerInputs()
    {
        string[,] inputs = GetInput();
        for (int i = 0; i < inputs.Length; i++)
        {
            if(!idCreated)
            {
                CreatePlayer(inputs[i, 0], i);
            }
            // Input comes in as [{id=123, forward=1, horizontal=-1, action=0},...]
            ApplyMovement(inputs[i, 0], inputs[i, 1], inputs[i, 2], inputs[i, 3]);
        }
    }

    void ApplyMovement(string id, string forward, string right, string action)
    {
        GameObject player = playerList[id].gameObject;
        //player.GetComponent<Player>().MovePlayer();
        // Call a movement function from Player script to move that specific player.
        player.GetComponent<Player>().PlayerMovement(forward, right);
        if (action == "1")
        {
            player.GetComponent<Player>().Fire();
        }
    }

    void CreatePlayer(string id, int i)
    {
        playerArr[i].GetComponent<Player>().id = id;
    }
}
