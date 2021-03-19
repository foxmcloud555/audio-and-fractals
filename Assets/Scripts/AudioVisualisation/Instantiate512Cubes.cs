using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {

    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
    public float colorCorrection;  
    private float decValue;
    public Color soundColor = Color.black;


    public float colorCorrectionPublic;
    public string hexValuePublic;
    public float decValuePublic;
    public Color soundColorPublic = Color.black;

    // Use this for initialization
    void Start () {
		for (int i = 0; i < 512; i ++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;


        }
	}
	
	// Update is called once per frame
	void Update () {
		
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(10, AudioVisualiserBaseEightBands._samples[i] * _maxScale + 2, 10);
                decValue = (int)_sampleCube[i].transform.localScale.y * colorCorrection;
                decValue = Mathf.Clamp(decValue, 0, 1);
                soundColor = Color.HSVToRGB(decValue, 0.8f, 0.8f);
                _sampleCube[i].GetComponent<MeshRenderer>().material.color = soundColor;
            }
        }

        _sampleCube[10].transform.localScale = new Vector3(10, AudioVisualiserBaseEightBands._samples[10] * _maxScale + 2, 10);
        decValuePublic = _sampleCube[10].transform.localScale.y * colorCorrectionPublic;
        decValuePublic = Mathf.Clamp(decValuePublic, 0, 1);
        soundColorPublic = Color.HSVToRGB(decValuePublic, 0.8f, 0.8f);
        

    }
}
