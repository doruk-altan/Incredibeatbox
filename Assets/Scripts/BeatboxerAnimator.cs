using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatboxerAnimator : MonoBehaviour
{
    [SerializeField] private Beatboxer beatboxer;

    private const string IS_ACTIVE = "IsActive";
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(IS_ACTIVE, beatboxer.IsActive());
    }
}
