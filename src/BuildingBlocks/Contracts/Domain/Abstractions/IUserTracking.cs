﻿namespace Contracts.Domains.Interfaces;

public interface IUserTracking
{
    string CreatedBy { get; set; }
    string UpdatedBy { get; set; }
    string DeletedBy { get; set; }
}
