using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material MAT_Dissolve;
    public float MaxTime = 5f;
    private bool _Dissolve = false;
    private float _currentTime;
    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0;
        MAT_Dissolve.SetFloat("_DissolveAmount", 0);
    }

    public void DoDissolve()
    {
        _Dissolve = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Dissolve && _currentTime <= MaxTime)
        {
            _currentTime += Time.deltaTime;
            MAT_Dissolve.SetFloat("_DissolveAmount", (_currentTime / MaxTime));
            gameObject.layer = 9;
        }
        if (_currentTime >= MaxTime - 1)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
        if (_currentTime >= MaxTime)
        {
            Destroy(gameObject);
        }
    }
}
