using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyService
{
    public class GenericServiceManager
    {
        protected virtual IEnumerable GetAllGenericServiceImplentations()
        {
            return new List<IGenericService>();
        }

        public void ProcessAll()
        {
            foreach (IGenericService igso in GetAllGenericServiceImplentations())
                igso.doJob();
        }
    }
}
