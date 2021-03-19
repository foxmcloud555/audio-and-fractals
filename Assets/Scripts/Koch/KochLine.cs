using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class KochLine : KochGenerator {

    LineRenderer _lineRenderer;
    [Range(0,1)]
    public float _lerpAmount;
    Vector3[] _lerpPosition;
    public float _generateMultiplyer;
    private float[] _lerpAudio;

    [Header("Audio")]
    public AudioVisualiserBaseEightBands _audioVisualiser;
    public int[] _audioBand;
    public Material _material;
    public Color _color;
    private Material _matInstance;
    public int _audioBandMaterial;
    public float _emissionMultiplier;




    // Use this for initialization
    void Start()
    {
        _lerpAudio = new float[_initiatorPointAmount];
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = true;
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.loop = true;
        _lineRenderer.positionCount = _position.Length;
        _lineRenderer.SetPositions(_position);
        _lerpPosition = new Vector3[_position.Length];

        //apply material
        _matInstance = new Material(_material);
        _lineRenderer.material = _matInstance;

        _audioBand = new int[_initiatorPointAmount];
        for (int i = 0; i < _initiatorPointAmount; i++)
        {
            _audioBand[i] = i;
        }
    }

	
	// Update is called once per frame
	void Update () {

        _matInstance.SetColor("_EmissionColor", _color * AudioVisualiserBaseEightBands._audioBandBuffer[_audioBandMaterial] * _emissionMultiplier);


        if(_generationCount != 0)
        {
            int count = 0;
            for (int i = 0; i < _initiatorPointAmount; i++)
            {
                _lerpAudio[i] = AudioVisualiserBaseEightBands._audioBandBuffer[_audioBand[i]];
                for (int j = 0; j < (_position.Length -1) / _initiatorPointAmount; j++ )
                {
                    _lerpPosition[count] = Vector3.Lerp(_position[count], _targetPosition[count], _lerpAudio[i]);
                    count++;
                }
            }

            _lerpPosition[count] = Vector3.Lerp(_position[count], _targetPosition[count], _lerpAudio[_initiatorPointAmount -1]);

            if ( _useBezierCurves)
            {
                _bezierPosition = BezierCurve(_lerpPosition, _bezierVertexCount);
                _lineRenderer.positionCount = _bezierPosition.Length;
                _lineRenderer.SetPositions(_bezierPosition);
            }
            else
            {
                _lineRenderer.positionCount = _lerpPosition.Length;
                _lineRenderer.SetPositions(_lerpPosition);
            }
            
        }		

    }
}
