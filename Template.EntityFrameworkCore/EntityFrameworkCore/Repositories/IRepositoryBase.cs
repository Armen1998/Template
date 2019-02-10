using System;
using System.Collections.Generic;
using System.Text;

namespace Template.EntityFrameworkCore.Repositories
{
    public interface IRepositoryBase
    {
        void Create();
        void CreateAsync();        
        void Update();
        void UpdateAsync();
        void Delete();
        void DeleteAsync();

       
    }
}
