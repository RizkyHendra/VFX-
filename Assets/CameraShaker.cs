using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _positionStrength;
    [SerializeField] private Vector3 _rotationStrength;

    private static event Action Shake;
    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShake;
    private void OnDisable() => Shake -= CameraShake;

    private void CameraShake()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(.3f, _positionStrength);
        _camera.DOShakeRotation(.3f, _rotationStrength);
    }
}
