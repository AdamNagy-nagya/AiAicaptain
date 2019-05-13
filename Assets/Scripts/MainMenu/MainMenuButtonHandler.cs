using UnityEngine;

class MainMenuButtonHandler : MonoBehaviour
{

    private ISceneRouter sceneRouter;

    void Start()
    {
        sceneRouter = new SceneRouter();
    }

   

    public void OnButtonSelected(int SceneId)
    {
        if (SceneId == 0)
        {
            sceneRouter.exitApplication();
        }
        else
        {
            sceneRouter.loadMapNumber(SceneId);
        }
    }
}
