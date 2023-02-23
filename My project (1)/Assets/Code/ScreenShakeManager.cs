using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeManager : MonoBehaviour
{
    public static ScreenShakeManager Instance;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private float randomness = 90f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShakeScreen()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
    }
}
