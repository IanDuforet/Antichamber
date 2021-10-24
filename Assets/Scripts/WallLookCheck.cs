using UnityEngine;

public class WallLookCheck : MonoBehaviour
{
    public GameObject CharacterCam;
    public Dissolve Wall;
    private float _Counter;
    public float MaxTime = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_Counter >= MaxTime)
        {
            Wall.DoDissolve();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        int layerMask = LayerMask.GetMask("DissolveWall");
        Ray r = new Ray(CharacterCam.transform.position, CharacterCam.transform.forward);
        RaycastHit info;
        if (Physics.Raycast(r, out info, 10, layerMask))
        {
            _Counter += Time.deltaTime;
        }
        else
        {
            _Counter = 0;
        }

    }

}
