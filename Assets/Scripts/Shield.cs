using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool isShieldActive = false;
    [SerializeField] private GameObject bubbleShield;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer != null)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }        
    }
}
