using UnityEngine;
using System.Collections;



public class UIManager : MonoBehaviour
{

    public GameObject superCanvas;

    const string pfbName_mainMenu = "pfb_mainMenu";
    const string pfbName_gameOver = "pfb_gameOver";
    const string pfbName_hud = "pfb_hud";
    const string pfbName_store = "pfb_store";

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void btnPlayPressed () {

		Debug.Log("btnPlayPressed");
		Application.LoadLevel("GameScene");
	}


    public void loadUIMainMenu () {
    
        // Load prefab from resource folder and instantiate.

        GameObject ui = (GameObject) Instantiate(Resources.Load(pfbName_mainMenu));
        ui.transform.SetParent(superCanvas.transform, false);
    }
}
