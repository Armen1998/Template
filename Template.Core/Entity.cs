using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Core
{
    /// <summary>
    /// This entity includes Id with type int.
    /// </summary>
    public class Entity : Entity<int>
    {        

    }

    /// <summary>
    /// This entity includes Id with type T.
    /// </summary>
    /// <typeparam name="T">T is value type.</typeparam>
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
