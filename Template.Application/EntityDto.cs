using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application
{
    public class EntityDto : EntityDto<int>
    {

    }

    /// <summary>
    /// This entity includes Id with type T.
    /// </summary>
    /// <typeparam name="T">T is value type.</typeparam>
    public class EntityDto<T> where T : struct
    {
        public T Id { get; set; }
    }
}
