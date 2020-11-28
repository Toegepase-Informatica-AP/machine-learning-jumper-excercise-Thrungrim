using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using TMPro;

public class Cop : Agent
{
    public float force = 25f;
    private Rigidbody body = null;
    public Transform orig = null;
    /*private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            Thrust();
        }
    }*/
    public override void Initialize()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        if (vectorAction[0] == 1)
        {
            Thrust();
        }
    }
    public override void OnEpisodeBegin()
    {
        ResetPlayer();
    }
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            actionsOut[0] = 1;
        }
    }
    private void ResetPlayer()
    {
        transform.position = new Vector3(orig.position.x, orig.position.y, orig.position.z);
    }

    private void Thrust()
    {
        body.AddForce(Vector3.up * force, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("villain") == true)
        {
            AddReward(-1f);
            Destroy(collision.gameObject);
            EndEpisode();
        }

        if (collision.transform.CompareTag("walltop"))
        {
            AddReward(-1f);
            EndEpisode();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wallreward") == true)
        {
            AddReward(0.1f);
        }
    }
}
