using Dev3Lib;
using Dev3Lib.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.DAL
{
    public class BugInfo : Interfaces.IBugInfo
    {
        private IDbContext _dbContext;
        public BugInfo(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Entities.SimpleBugInfo> ReturnSimpleBugInfo(string programmer, DateTime startDate, DateTime endDate)
        {
            DependencyFactory.Resolve<IDbContext>().Commit();
            return null;
        }
    }
}
