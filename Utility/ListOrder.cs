using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Entity;

namespace TeamView.Utility
{
    class ListOrder
    {
        public BindingCollection<BugInfoEntity> GetListOrder(List<BugInfoEntity> list)
        {
            BindingCollection<BugInfoEntity> objList = new BindingCollection<BugInfoEntity>();
            foreach (BugInfoEntity item in list)
            {
                objList.Add(item);
            }
            return objList;
        }
    }
}
