namespace ConnectSea.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; } = 0;

    public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? DateModified { get; private set; } = null;

    protected void SetDateModified()
    {
        DateModified = DateTimeOffset.UtcNow;
    }
}
