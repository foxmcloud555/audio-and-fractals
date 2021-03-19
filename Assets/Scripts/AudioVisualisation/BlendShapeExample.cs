//Using C#

using UnityEngine;
using System.Collections;

public class BlendShapeExample : MonoBehaviour
{

    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    Material _material;

    public bool _useBuffer;

    public int _band;
    public float _startScale, _scaleMultiplier;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        _material = skinnedMeshRenderer.material;
    }

    void Start()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;
    }

    void Update()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, (AudioVisualiserBaseEightBands._bandBuffer[_band] * _scaleMultiplier));

        if (_useBuffer)
        {
            Color _color = new Color(AudioVisualiserBaseEightBands._audioBandBuffer[_band], AudioVisualiserBaseEightBands._audioBandBuffer[_band], AudioVisualiserBaseEightBands._audioBandBuffer[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        else
        {
            Color _color = new Color(AudioVisualiserBaseEightBands._audioBand[_band], AudioVisualiserBaseEightBands._audioBand[_band], AudioVisualiserBaseEightBands._audioBand[_band]);
            _material.SetColor("_EmissionColor", _color);
        }

    }
}