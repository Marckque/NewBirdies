using UnityEngine;

public class Reflex : Item
{
    [SerializeField]
    private Canvas lensUI;
    private bool isUsingLens;

    public override void OnActivation()
    {
        base.OnActivation();
        EndLensCustomization();
    }

    public override void OnDeactivation()
    {
        base.OnDeactivation();
        EndLensCustomization();
    }

    protected override void MainAction()
    {
        base.MainAction();
        TakePicture();
    }

    protected override void SecondaryAction()
    {
        base.SecondaryAction();
        Lens();
    }

    private void TakePicture()
    {
        print("Le petit oiseau est sorti, hihi !");
    }

    private void Lens() // Bad name ; it doesn't describe an action
    {
        isUsingLens = !isUsingLens;

        if (isUsingLens)
        {
            StartLensCustomization();
        }
        else
        {
            EndLensCustomization();
        }
    }

    private void StartLensCustomization()
    {
        lensUI.enabled = true;
    }

    private void EndLensCustomization()
    {
        isUsingLens = false;
        lensUI.enabled = false;
    }
}