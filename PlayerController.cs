using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5f;
    public float rotationVelocity = 5f;
    public float forceAmount = 100f;

    public static PlayerController instance;

    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        if (instance)
            Destroy(instance);
        instance = this;

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVector = transform.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVector = -transform.up;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -rotationVelocity) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, rotationVelocity) * Time.deltaTime);
        }

        transform.localPosition += moveVector * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            DoPhysicsStuff();
        }
    }

    private void DoPhysicsStuff()
    {
        playerRigidbody.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
    }

    public void CheckForHealth(int currentHealth)
    {
        if (currentHealth <= 0)
            StartCoroutine(DestroyObjectAfterSomeTime(1f));
    }

    private IEnumerator DestroyObjectAfterSomeTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
