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
    /// Controller class for bugDoc
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BugDocController
    {
        // Preload our schema..
        BugDoc thisSchemaLoad = new BugDoc();
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
        public BugDocCollection FetchAll()
        {
            BugDocCollection coll = new BugDocCollection();
            Query qry = new Query(BugDoc.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BugDocCollection FetchByID(object BugNum)
        {
            BugDocCollection coll = new BugDocCollection().Where("bugNum", BugNum).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BugDocCollection FetchByQuery(Query qry)
        {
            BugDocCollection coll = new BugDocCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object BugNum)
        {
            return (BugDoc.Delete(BugNum) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object BugNum)
        {
            return (BugDoc.Destroy(BugNum) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string BugNum,byte[] Doc)
	    {
		    BugDoc item = new BugDoc();
		    
            item.BugNum = BugNum;
            
            item.Doc = Doc;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string BugNum,byte[] Doc)
	    {
		    BugDoc item = new BugDoc();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.BugNum = BugNum;
				
			item.Doc = Doc;
				
	        item.Save(UserName);
	    }
    }
}