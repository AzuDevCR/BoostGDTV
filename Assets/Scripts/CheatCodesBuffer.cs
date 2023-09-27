using UnityEngine;

public class CheatCodesBuffer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] string nextLevelCode = "letmego";
    [SerializeField] string noCollisionsCode = "letmefly";
    string userCode = "";

    void Update()
    {
        KeyboardBufferCheck();
    }

    void KeyboardBufferCheck() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space)) {
            userCode = "";
        }
        else {
            VerifyCheatCode(CheckInput());
        }
    }

    string CheckInput() {
        
        if (Input.anyKeyDown) {
            userCode += Input.inputString;
        }
        
        return userCode;
    }

    void VerifyCheatCode(string code) {
        if (code.Equals(nextLevelCode)) {
            Debug.Log("Going to the next Level!!");
            Player.GetComponent<CollisionHandler>().LoadNextLevel();
            userCode = "";
        }
        else if (code.Equals(noCollisionsCode)) {
            Debug.Log("God mode activated!!");
            Player.GetComponent<CollisionHandler>().SetCollisionState();
            userCode = "";
        }
    }
}
