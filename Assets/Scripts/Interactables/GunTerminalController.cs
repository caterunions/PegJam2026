using UnityEngine;

public class GunTerminalController : InteractableController
{
    [SerializeField]
    private GameObject gunArmPivot;

    [SerializeField]
    private Transform gunMuzzle;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float maxAngle;
    [SerializeField]
    private float minAngle;

    private float angle;
    private float lastKnownYInput;
    private bool needsReset;

    public override void HandleInput(Vector2 input)
    {
        lastKnownYInput = input.y;

        if(input.x > 0.8 && !needsReset)
        {
            Fire();
            needsReset = true;
        }
        else
        {
            needsReset = false;
        }
    }

    public void Fire()
    {
        Instantiate(bullet, gunMuzzle.position, gunMuzzle.rotation);
    }

    private void Update()
    {
        angle += lastKnownYInput * turnSpeed * Time.deltaTime * -1;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        gunArmPivot.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
