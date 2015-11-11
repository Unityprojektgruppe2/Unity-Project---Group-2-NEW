using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Menu currentMenu;

	// Use this for initialization
	void Start ()
    {
        ShowMenu(currentMenu);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Makes a "default" menu, if there is not selected a current menu.
    public void ShowMenu(Menu menu)
    {
        if (currentMenu != null)
        {
            currentMenu.isOpen = false;
        }

        currentMenu = menu;
        currentMenu.isOpen = true;
    }
}
