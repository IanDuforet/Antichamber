using UnityEngine;

public class camMouseLook : MonoBehaviour
{
    public float sensitiviy = 200f;


    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        transform.Rotate(new Vector3(-md.y, 0, 0) * sensitiviy * Time.deltaTime, Space.Self);

        transform.parent.parent.Rotate(new Vector3(0, md.x, 0) * sensitiviy * Time.deltaTime, Space.Self);

    }
}
