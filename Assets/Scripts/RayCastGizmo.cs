using UnityEngine;

public class RayCastGizmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray r = new Ray(gameObject.transform.position, gameObject.transform.forward * 10);
        Gizmos.DrawRay(r);

    }

}
