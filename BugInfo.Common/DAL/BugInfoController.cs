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
    /// Controller class for bugInfo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BugInfoController
    {
        // Preload our schema..
        BugInfo thisSchemaLoad = new BugInfo();
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
        public BugInfoCollection FetchAll()
        {
            BugInfoCollection coll = new BugInfoCollection();
            Query qry = new Query(BugInfo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BugInfoCollection FetchByID(object BugNum)
        {
            BugInfoCollection coll = new BugInfoCollection().Where("bugNum", BugNum).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BugInfoCollection FetchByQuery(Query qry)
        {
            BugInfoCollection coll = new BugInfoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object BugNum)
        {
            return (BugInfo.Delete(BugNum) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object BugNum)
        {
            return (BugInfo.Destroy(BugNum) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(string BugNum,int MoveSequence)
        {
            Query qry = new Query(BugInfo.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("BugNum", BugNum).AND("MoveSequence", MoveSequence);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Version,string BugNum,int MoveSequence,string BugStatus,string DealMan,DateTime CreatedTime,string Description,int Size,int Fired,DateTime TimeStamp,short Priority,short HardLevel)
	    {
		    BugInfo item = new BugInfo();
		    
            item.Version = Version;
            
            item.BugNum = BugNum;
            
            item.MoveSequence = MoveSequence;
            
            item.BugStatus = BugStatus;
            
            item.DealMan = DealMan;
            
            item.CreatedTime = CreatedTime;
            
            item.Description = Description;
            
            item.Size = Size;
            
            item.Fired = Fired;
            
            item.TimeStamp = TimeStamp;
            
            item.Priority = Priority;
            
            item.HardLevel = HardLevel;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Version,string BugNum,int MoveSequence,string BugStatus,string DealMan,DateTime CreatedTime,string Description,int Size,int Fired,DateTime TimeStamp,short Priority,short HardLevel)
	    {
		    BugInfo item = new BugInfo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Version = Version;
				
			item.BugNum = BugNum;
				
			item.MoveSequence = MoveSequence;
				
			item.BugStatus = BugStatus;
				
			item.DealMan = DealMan;
				
			item.CreatedTime = CreatedTime;
				
			item.Description = Description;
				
			item.Size = Size;
				
			item.Fired = Fired;
				
			item.TimeStamp = TimeStamp;
				
			item.Priority = Priority;
				
			item.HardLevel = HardLevel;
				
	        item.Save(UserName);
	    }
    }
}
