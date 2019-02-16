using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Core
{
    /// <summary>
    /// This IEntity includes Id with type int.
    /// </summary>
    public interface IEntity : IEntity<int>
    {
        
    }


    /// <summary>
    /// This IEntity includes Id with type T.
    /// </summary>
    /// <typeparam name="T">T is value type.</typeparam>
    public interface IEntity<TPrimaryKey> 
    {
        TPrimaryKey Id { get; set; }
    }
}
