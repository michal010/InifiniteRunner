using UnityEngine;

public class MapSegment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Generate next segment, delete old, generate obstacles
            GameManager.Instance.Game.LevelGenerator.OnPlayerEnteredAnySegment();
        }
    }
}
