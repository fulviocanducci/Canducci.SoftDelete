using Canducci.SoftDelete;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestSoftDelete.Models
{
    public class ModelBool: ISoftDeleteBool
    {
        public Guid Id { get; set; }

        public bool DeletedAt { get; } = false;
    }
}
