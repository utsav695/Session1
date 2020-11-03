using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5f;
    public float rotationVelocity = 5f;

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
    }
}
