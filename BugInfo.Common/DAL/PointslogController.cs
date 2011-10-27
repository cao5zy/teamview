using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace DAL
{
    /// <summary>
    /// Controller class for pointslog
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PointslogController
    {
        // Preload our schema..
        Pointslog thisSchemaLoad = new Pointslog();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public PointslogCollection FetchAll()
        {
            PointslogCollection coll = new PointslogCollection();
            Query qry = new Query(Pointslog.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PointslogCollection FetchByID(object Pointslogid)
        {
            PointslogCollection coll = new PointslogCollection().Where("pointslogid", Pointslogid).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PointslogCollection FetchByQuery(Query qry)
        {
            PointslogCollection coll = new PointslogCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Pointslogid)
        {
            return (Pointslog.Delete(Pointslogid) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Pointslogid)
        {
            return (Pointslog.Destroy(Pointslogid) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Bugnum,string Log,DateTime Createdtime)
	    {
		    Pointslog item = new Pointslog();
		    
            item.Bugnum = Bugnum;
            
            item.Log = Log;
            
            item.Createdtime = Createdtime;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(long Pointslogid,string Bugnum,string Log,DateTime Createdtime)
	    {
		    Pointslog item = new Pointslog();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Pointslogid = Pointslogid;
				
			item.Bugnum = Bugnum;
				
			item.Log = Log;
				
			item.Createdtime = Createdtime;
				
	        item.Save(UserName);
	    }
    }
}
