using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform bar;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SetState(float current, float max)
    {
        float state = (float)current;
        state/=max;
        if(state<0f)state = 0f;
        bar.transform.localScale=new Vector3(state,1f,1f);
        audioSource.Play();
    }

}
