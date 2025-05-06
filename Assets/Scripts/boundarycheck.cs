using UnityEngine;

public class boundarycheck : MonoBehaviour
{
    public int boundaryChecked;
    public bool checked1;
    public bool checked2;

    public GameObject boundary1;
    public GameObject boundary2;
    public GameObject tip1;
    public GameObject tip2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boundaryChecked = 0;
        boundary1.SetActive(true);
        boundary2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(boundaryChecked == 1)
            checked1 = true;

        else if(boundaryChecked == 2)
            checked2 = true;

        TipChange();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        boundaryChecked++;
    }

    public void TipChange()
    {
        if (checked1)
        {
            boundary1.SetActive(false);
            boundary2.SetActive(true);
            tip1.SetActive(false);
            tip2.SetActive(true);
        }

        if (checked2)
        {
            boundary2.SetActive(false);
            tip2.SetActive(false);
        }
    }
}
