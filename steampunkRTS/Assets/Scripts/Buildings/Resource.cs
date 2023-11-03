public class Resource : WorldObject {
    public float capacity;

    protected float amountLeft;
    protected ResourceType resourcetype;

    protected override void Start()
    {
        base.Start();
        amountLeft = capacity;
        resourceType = ResourceType.Unknown;
    }
    public void Remove(float amount)
    {
        amountLeft -= amount;
        if (amountLeft < 0) amountLeft = 0;
    }
    public bool isEmpty()
    {
        return amountLeft <= 0;
    }
    public ResourceType GetResourceType()
    {
        return resourcetype;
    }
}