using UnityEngine;

public class teleportScript : MonoBehaviour
{
    // Start is called before the first frame update
    public characterController charScript;
    public float Offset = 15f;
    public Transform Target;
    public float Rotate = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Rotate != 0)
        {
            Quaternion newRotation = other.transform.rotation * Quaternion.Euler(0, Rotate, 0);
            other.transform.rotation = newRotation;
        }
        Vector3 playerPos = other.transform.position;
        playerPos += (Target.transform.position - transform.position);

        charScript.teleport(playerPos);
        Debug.Log("Teleport");
    }

}
