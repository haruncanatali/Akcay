﻿using Akcay.Domain.Enums;

namespace Akcay.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
}