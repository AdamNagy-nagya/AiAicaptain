
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItemHover : MonoBehaviour
{
    private Renderer rend;
    public int SceneId = 0;

    private ISceneRouter sceneRouter;

    void Start()
    {
        sceneRouter = new SceneRouter();
        rend = GetComponent<Renderer>();
        rend.material.color = Color.black;
    }

    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.black;
    }


    void OnMouseUp()
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
