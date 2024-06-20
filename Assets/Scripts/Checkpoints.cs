using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CheckpointReached();
        }
    }
}
