using UnityEngine;

public class teleportScriptCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public characterController charScript;
    public float Offset = 15f;
    public Transform Target;
    public int Rotate = 0;
    private int _counter;
    public int _amount = 2;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(_counter >= _amount)
        {
        if (Rotate != 0)
        {
            Quaternion newRotation = other.transform.rotation * Target.rotation;
            other.transform.rotation = newRotation;

        }
        Vector3 playerPos = other.transform.position;
        playerPos += (Target.transform.position - transform.position);

        charScript.teleport(playerPos);
        Debug.Log("Teleport");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        _counter++;


    }

}
