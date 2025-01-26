using UnityEngine;

public class DeactivateCanva : MonoBehaviour
{
    [SerializeField]
    private GameObject startScreen;

    public void Deactivate()
    {
        startScreen.SetActive(false);
    }
}
