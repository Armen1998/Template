using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application
{
    /// <summary>
    /// This IEntityDto includes Id with type int.
    /// </summary>
    public interface IEntityDto : IEntityDto<int>
    {

    }

    /// <summary>
    /// This IEntityDto includes Id with type T.
    /// </summary>
    /// <typeparam name="T">T is value type.</typeparam>
    public interface IEntityDto<TPrimaryKey>
        where TPrimaryKey : struct
    {
        TPrimaryKey Id { get; set; }
    }
}
