using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform player;
    private Rigidbody2D playerRB;
    [SerializeField] private float speed;
    
    private Vector3 velocity;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float lookAheadDistance = 0.2f;
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player").transform;
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void LateUpdate()
    {
        Vector3 targetPosition = player.position;

        targetPosition += (Vector3)playerRB.linearVelocity.normalized * lookAheadDistance;

        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}