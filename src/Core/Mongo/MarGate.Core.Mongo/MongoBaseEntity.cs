﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MarGate.Core.Mongo;

public class MongoBaseEntity
{
    [BsonId]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public DateTime CreatedDate { get; } = DateTime.Now;

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get => _modifiedDate;
        private set => _modifiedDate = value;
    }

    public bool IsDeleted { get; protected set; } = false;

    public void MarkAsModified()
    {
        ModifiedDate = DateTime.Now;
    }

    public void MarkAsDeleted()
    {
        if (IsDeleted)
        {
            throw new InvalidOperationException($"This entity has already been deleted. Cannot delete again. (ID: {Id})");
        }

        IsDeleted = true;
        MarkAsModified();
    }

    public void Restore()
    {
        if (!IsDeleted)
        {
            throw new InvalidOperationException($"This entity is not deleted. Cannot restore. (ID: {Id})");
        }

        IsDeleted = false;
        MarkAsModified();
    }
}
