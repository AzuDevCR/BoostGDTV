using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;        
    }
}
