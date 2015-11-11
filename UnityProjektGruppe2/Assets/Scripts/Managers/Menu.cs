using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private Animator _animator;
    private CanvasGroup _canvasGroup;

    public bool isOpen
    {
        get { return _animator.GetBool("isOpen"); }
        set { _animator.SetBool("isOpen", value); }
    }


    // Use this for initialization
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _canvasGroup = GetComponent<CanvasGroup>();

        //Sets the menu(s) to the center of the canvas, in the start
        RectTransform rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
    }

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Checks if the animation runs(Open), and enables/disables interaction with it
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
        }
        else
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
        }
	}
}
