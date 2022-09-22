using dnd_dal.dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace dnd_service_logic
{
    public abstract class BaseLogic
    {
        protected dndContext db { get; set; }

        public BaseLogic()
        {
            db = new dndContext();
        }

        protected void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}
