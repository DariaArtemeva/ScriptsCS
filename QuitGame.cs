using UnityEngine;
using UnityEngine.SceneManagement;
namespace Valve.VR.InteractionSystem.Sample
{ 
public class QuitGame : UIElement
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        Application.Quit();

        Debug.Log("Game is exiting");
    }

}
}


