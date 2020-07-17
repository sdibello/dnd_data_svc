using System;
using System.Collections.Generic;
using System.Text;

namespace dnd_dal.query.feat
{
    public class FeatQuery
    {
        private readonly dndContext _context;

        public FeatQuery(dndContext context)
        {
            _context = context;
        }


    }
}
