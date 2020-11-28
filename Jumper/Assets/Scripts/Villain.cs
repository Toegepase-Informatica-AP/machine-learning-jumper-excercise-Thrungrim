using UnityEngine;

public class Villain : MonoBehaviour
{
    public float MoveSpeed = 3.5f;

    public void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wallend") == true)
        {
            Destroy(gameObject);
        }/*

        if (collision.gameObject.CompareTag("cop") == true)
        {
            Destroy(gameObject);
        }*/
    }
}
