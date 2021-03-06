using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualiserBase : MonoBehaviour {

    AudioSource _audioSource;
    [SerializeField]
    public static float[] _samples = new float[512];

	// Use this for initialization
	void Start () {
        _audioSource = GetComponent<AudioSource>();

		
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();

    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
}
