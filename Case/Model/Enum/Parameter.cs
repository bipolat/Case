using System;

namespace Case.Model.Enum
{
    partial class Enum
    {
        enum ErrorLog : int
        {
            None = 0,
            Unknown = 1,
            ConnectionLost = 2,
            OutlierReading = 3
        }
        enum AuditLog : int
        {
            None = 0,
            GetByID = 1,
            GetAll = 2,
            Add = 3,
            Remove = 4
        }
    }
}
