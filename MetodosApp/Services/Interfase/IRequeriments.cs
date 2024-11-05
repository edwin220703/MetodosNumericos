using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Services.Interfase
{
    interface IRequeriments<T>
    {
        public void Logic();

        public List<T> GetAllResult();
    }
}
