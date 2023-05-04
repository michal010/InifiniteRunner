using UnityEngine;

public struct MovingObstacleData
{
    public IPlayer Player;
    public float ForwardMovementSpeed;
}


[FromFactory("MovingObstacle", true)]
public class MovingObstacle : MonoBehaviour
{
    private bool isDestroying = false;
    public MovingObstacleData Data;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroying)
            return;
        Move();
        CheckForDeletion();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Data.ForwardMovementSpeed);
        transform.LookAt(Data.Player.Transform);
    }

    private void CheckForDeletion()
    {
        if (Data.Player.Transform.position.z > transform.position.z)
        {
            isDestroying = true;
            Destroy(gameObject, 3f);
        }
    }
}
