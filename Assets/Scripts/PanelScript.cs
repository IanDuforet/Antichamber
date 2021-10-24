using UnityEngine;
using UnityEngine.UI;
public class PanelScript : MonoBehaviour
{
    public float MaxTime = 5f;
    private bool _goAplha = false;
    private float _currentTime;
    public Image thisColor;
    // Start is called before the first frame update
    void Start()
    {
        thisColor = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_goAplha && _currentTime <= MaxTime)
        {
            _currentTime += Time.deltaTime;
            Color temp = thisColor.color;
            temp.a = 1 - _currentTime/MaxTime;
            thisColor.color = temp;
        }
    }

    public void ChangeOpacity()
    {
        _goAplha = true;
    }

}
