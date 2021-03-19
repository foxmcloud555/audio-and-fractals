using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField]
    private Transform propeller1;
    [SerializeField]
    private Transform propeller2;
    [SerializeField]
    private Transform propeller3;

    private double time = 0;


    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        SpinMill(propeller1, 1);
        SpinMill(propeller2, 3);
        SpinMill(propeller3, 7);
    }

    void SpinMill(Transform prop, int band)
    {
        prop.localRotation = Quaternion.Euler(new Vector3((float)time * 10 + AudioVisualiserBaseEightBands._bandBuffer[band] * speed, 0, 0));
        if (prop.localRotation.y > 360)
        {
            prop.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
