using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isHiding = false;
    public void SetHiding(bool hiding)
    {
        isHiding = hiding;
    }
    public bool IsHiding()
    {
        return isHiding;
    }
}