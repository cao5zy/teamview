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
	/// Strongly-typed collection for the ChangeLog class.
	/// </summary>
    [Serializable]
	public partial class ChangeLogCollection : ActiveList<ChangeLog, ChangeLogCollection>
	{	   
		public ChangeLogCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ChangeLogCollection</returns>
		public ChangeLogCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ChangeLog o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the ChangeLog table.
	/// </summary>
	[Serializable]
	public partial class ChangeLog : ActiveRecord<ChangeLog>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ChangeLog()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ChangeLog(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ChangeLog(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ChangeLog(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("ChangeLog", TableType.Table, DataService.GetInstance("BugInfoProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarLogID = new TableSchema.TableColumn(schema);
				colvarLogID.ColumnName = "LogID";
				colvarLogID.DataType = DbType.Int64;
				colvarLogID.MaxLength = 0;
				colvarLogID.AutoIncrement = true;
				colvarLogID.IsNullable = false;
				colvarLogID.IsPrimaryKey = true;
				colvarLogID.IsForeignKey = false;
				colvarLogID.IsReadOnly = false;
				colvarLogID.DefaultSetting = @"";
				colvarLogID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogID);
				
				TableSchema.TableColumn colvarBugNum = new TableSchema.TableColumn(schema);
				colvarBugNum.ColumnName = "BugNum";
				colvarBugNum.DataType = DbType.AnsiString;
				colvarBugNum.MaxLength = 20;
				colvarBugNum.AutoIncrement = false;
				colvarBugNum.IsNullable = false;
				colvarBugNum.IsPrimaryKey = false;
				colvarBugNum.IsForeignKey = true;
				colvarBugNum.IsReadOnly = false;
				colvarBugNum.DefaultSetting = @"";
				
					colvarBugNum.ForeignKeyTableName = "bugInfo";
				schema.Columns.Add(colvarBugNum);
				
				TableSchema.TableColumn colvarCreateDate = new TableSchema.TableColumn(schema);
				colvarCreateDate.ColumnName = "CreateDate";
				colvarCreateDate.DataType = DbType.DateTime;
				colvarCreateDate.MaxLength = 0;
				colvarCreateDate.AutoIncrement = false;
				colvarCreateDate.IsNullable = false;
				colvarCreateDate.IsPrimaryKey = false;
				colvarCreateDate.IsForeignKey = false;
				colvarCreateDate.IsReadOnly = false;
				
						colvarCreateDate.DefaultSetting = @"(getdate())";
				colvarCreateDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreateDate);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 80;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarLogTypeID = new TableSchema.TableColumn(schema);
				colvarLogTypeID.ColumnName = "LogTypeID";
				colvarLogTypeID.DataType = DbType.Int32;
				colvarLogTypeID.MaxLength = 0;
				colvarLogTypeID.AutoIncrement = false;
				colvarLogTypeID.IsNullable = false;
				colvarLogTypeID.IsPrimaryKey = false;
				colvarLogTypeID.IsForeignKey = false;
				colvarLogTypeID.IsReadOnly = false;
				
						colvarLogTypeID.DefaultSetting = @"((0))";
				colvarLogTypeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogTypeID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["BugInfoProvider"].AddSchema("ChangeLog",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("LogID")]
		[Bindable(true)]
		public long LogID 
		{
			get { return GetColumnValue<long>(Columns.LogID); }
			set { SetColumnValue(Columns.LogID, value); }
		}
		  
		[XmlAttribute("BugNum")]
		[Bindable(true)]
		public string BugNum 
		{
			get { return GetColumnValue<string>(Columns.BugNum); }
			set { SetColumnValue(Columns.BugNum, value); }
		}
		  
		[XmlAttribute("CreateDate")]
		[Bindable(true)]
		public DateTime CreateDate 
		{
			get { return GetColumnValue<DateTime>(Columns.CreateDate); }
			set { SetColumnValue(Columns.CreateDate, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("LogTypeID")]
		[Bindable(true)]
		public int LogTypeID 
		{
			get { return GetColumnValue<int>(Columns.LogTypeID); }
			set { SetColumnValue(Columns.LogTypeID, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a BugInfo ActiveRecord object related to this ChangeLog
		/// 
		/// </summary>
		public DAL.BugInfo BugInfo
		{
			get { return DAL.BugInfo.FetchByID(this.BugNum); }
			set { SetColumnValue("BugNum", value.BugNum); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varBugNum,DateTime varCreateDate,string varDescription,int varLogTypeID)
		{
			ChangeLog item = new ChangeLog();
			
			item.BugNum = varBugNum;
			
			item.CreateDate = varCreateDate;
			
			item.Description = varDescription;
			
			item.LogTypeID = varLogTypeID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varLogID,string varBugNum,DateTime varCreateDate,string varDescription,int varLogTypeID)
		{
			ChangeLog item = new ChangeLog();
			
				item.LogID = varLogID;
			
				item.BugNum = varBugNum;
			
				item.CreateDate = varCreateDate;
			
				item.Description = varDescription;
			
				item.LogTypeID = varLogTypeID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn LogIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BugNumColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateDateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LogTypeIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string LogID = @"LogID";
			 public static string BugNum = @"BugNum";
			 public static string CreateDate = @"CreateDate";
			 public static string Description = @"Description";
			 public static string LogTypeID = @"LogTypeID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
