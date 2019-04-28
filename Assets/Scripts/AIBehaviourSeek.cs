
using UnityEngine;

public class AIBehaviourSeek : MonoBehaviour
{
    
    public Transform target;
    private Rigidbody2D rgb2d;


    private Vector3 velocity;
    public float MaxForce = 15f;
    public float MaxVelocity = 2;
    public float mass = 15;

    private void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var desiredVelocity = (target.transform.position - transform.position).normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;

        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        
        //transform.position += velocity * Time.deltaTime;


        //Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        //Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);
    }
    private void FixedUpdate()
    {
        rgb2d.velocity = velocity ;
    }

}
