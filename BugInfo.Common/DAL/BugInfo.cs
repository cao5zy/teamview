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
	/// Strongly-typed collection for the BugInfo class.
	/// </summary>
    [Serializable]
	public partial class BugInfoCollection : ActiveList<BugInfo, BugInfoCollection>
	{	   
		public BugInfoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>BugInfoCollection</returns>
		public BugInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                BugInfo o = this[i];
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
	/// This is an ActiveRecord class which wraps the bugInfo table.
	/// </summary>
	[Serializable]
	public partial class BugInfo : ActiveRecord<BugInfo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public BugInfo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public BugInfo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public BugInfo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public BugInfo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("bugInfo", TableType.Table, DataService.GetInstance("BugInfoProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarVersion = new TableSchema.TableColumn(schema);
				colvarVersion.ColumnName = "version";
				colvarVersion.DataType = DbType.AnsiString;
				colvarVersion.MaxLength = 50;
				colvarVersion.AutoIncrement = false;
				colvarVersion.IsNullable = false;
				colvarVersion.IsPrimaryKey = false;
				colvarVersion.IsForeignKey = false;
				colvarVersion.IsReadOnly = false;
				colvarVersion.DefaultSetting = @"";
				colvarVersion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVersion);
				
				TableSchema.TableColumn colvarBugNum = new TableSchema.TableColumn(schema);
				colvarBugNum.ColumnName = "bugNum";
				colvarBugNum.DataType = DbType.AnsiString;
				colvarBugNum.MaxLength = 20;
				colvarBugNum.AutoIncrement = false;
				colvarBugNum.IsNullable = false;
				colvarBugNum.IsPrimaryKey = true;
				colvarBugNum.IsForeignKey = false;
				colvarBugNum.IsReadOnly = false;
				colvarBugNum.DefaultSetting = @"";
				colvarBugNum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBugNum);
				
				TableSchema.TableColumn colvarBugStatus = new TableSchema.TableColumn(schema);
				colvarBugStatus.ColumnName = "bugStatus";
				colvarBugStatus.DataType = DbType.AnsiString;
				colvarBugStatus.MaxLength = 20;
				colvarBugStatus.AutoIncrement = false;
				colvarBugStatus.IsNullable = true;
				colvarBugStatus.IsPrimaryKey = false;
				colvarBugStatus.IsForeignKey = false;
				colvarBugStatus.IsReadOnly = false;
				colvarBugStatus.DefaultSetting = @"";
				colvarBugStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBugStatus);
				
				TableSchema.TableColumn colvarDealMan = new TableSchema.TableColumn(schema);
				colvarDealMan.ColumnName = "dealMan";
				colvarDealMan.DataType = DbType.AnsiString;
				colvarDealMan.MaxLength = 20;
				colvarDealMan.AutoIncrement = false;
				colvarDealMan.IsNullable = true;
				colvarDealMan.IsPrimaryKey = false;
				colvarDealMan.IsForeignKey = false;
				colvarDealMan.IsReadOnly = false;
				colvarDealMan.DefaultSetting = @"";
				colvarDealMan.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDealMan);
				
				TableSchema.TableColumn colvarCreatedTime = new TableSchema.TableColumn(schema);
				colvarCreatedTime.ColumnName = "createdTime";
				colvarCreatedTime.DataType = DbType.DateTime;
				colvarCreatedTime.MaxLength = 0;
				colvarCreatedTime.AutoIncrement = false;
				colvarCreatedTime.IsNullable = false;
				colvarCreatedTime.IsPrimaryKey = false;
				colvarCreatedTime.IsForeignKey = false;
				colvarCreatedTime.IsReadOnly = false;
				
						colvarCreatedTime.DefaultSetting = @"(getdate())";
				colvarCreatedTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedTime);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 500;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarSize = new TableSchema.TableColumn(schema);
				colvarSize.ColumnName = "size";
				colvarSize.DataType = DbType.Int32;
				colvarSize.MaxLength = 0;
				colvarSize.AutoIncrement = false;
				colvarSize.IsNullable = false;
				colvarSize.IsPrimaryKey = false;
				colvarSize.IsForeignKey = false;
				colvarSize.IsReadOnly = false;
				
						colvarSize.DefaultSetting = @"((0))";
				colvarSize.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSize);
				
				TableSchema.TableColumn colvarFired = new TableSchema.TableColumn(schema);
				colvarFired.ColumnName = "fired";
				colvarFired.DataType = DbType.Int32;
				colvarFired.MaxLength = 0;
				colvarFired.AutoIncrement = false;
				colvarFired.IsNullable = false;
				colvarFired.IsPrimaryKey = false;
				colvarFired.IsForeignKey = false;
				colvarFired.IsReadOnly = false;
				
						colvarFired.DefaultSetting = @"((0))";
				colvarFired.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFired);
				
				TableSchema.TableColumn colvarTimeStamp = new TableSchema.TableColumn(schema);
				colvarTimeStamp.ColumnName = "timeStamp";
				colvarTimeStamp.DataType = DbType.DateTime;
				colvarTimeStamp.MaxLength = 0;
				colvarTimeStamp.AutoIncrement = false;
				colvarTimeStamp.IsNullable = false;
				colvarTimeStamp.IsPrimaryKey = false;
				colvarTimeStamp.IsForeignKey = false;
				colvarTimeStamp.IsReadOnly = false;
				
						colvarTimeStamp.DefaultSetting = @"(getdate())";
				colvarTimeStamp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTimeStamp);
				
				TableSchema.TableColumn colvarPriority = new TableSchema.TableColumn(schema);
				colvarPriority.ColumnName = "priority";
				colvarPriority.DataType = DbType.Int16;
				colvarPriority.MaxLength = 0;
				colvarPriority.AutoIncrement = false;
				colvarPriority.IsNullable = false;
				colvarPriority.IsPrimaryKey = false;
				colvarPriority.IsForeignKey = false;
				colvarPriority.IsReadOnly = false;
				
						colvarPriority.DefaultSetting = @"((4))";
				colvarPriority.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPriority);
				
				TableSchema.TableColumn colvarHardLevel = new TableSchema.TableColumn(schema);
				colvarHardLevel.ColumnName = "hardLevel";
				colvarHardLevel.DataType = DbType.Int16;
				colvarHardLevel.MaxLength = 0;
				colvarHardLevel.AutoIncrement = false;
				colvarHardLevel.IsNullable = false;
				colvarHardLevel.IsPrimaryKey = false;
				colvarHardLevel.IsForeignKey = false;
				colvarHardLevel.IsReadOnly = false;
				
						colvarHardLevel.DefaultSetting = @"((0))";
				colvarHardLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHardLevel);
				
				TableSchema.TableColumn colvarLatestStartTime = new TableSchema.TableColumn(schema);
				colvarLatestStartTime.ColumnName = "latestStartTime";
				colvarLatestStartTime.DataType = DbType.DateTime;
				colvarLatestStartTime.MaxLength = 0;
				colvarLatestStartTime.AutoIncrement = false;
				colvarLatestStartTime.IsNullable = true;
				colvarLatestStartTime.IsPrimaryKey = false;
				colvarLatestStartTime.IsForeignKey = false;
				colvarLatestStartTime.IsReadOnly = false;
				colvarLatestStartTime.DefaultSetting = @"";
				colvarLatestStartTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLatestStartTime);
				
				TableSchema.TableColumn colvarDoc = new TableSchema.TableColumn(schema);
				colvarDoc.ColumnName = "Doc";
				colvarDoc.DataType = DbType.Binary;
				colvarDoc.MaxLength = 2147483647;
				colvarDoc.AutoIncrement = false;
				colvarDoc.IsNullable = true;
				colvarDoc.IsPrimaryKey = false;
				colvarDoc.IsForeignKey = false;
				colvarDoc.IsReadOnly = false;
				colvarDoc.DefaultSetting = @"";
				colvarDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDoc);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["BugInfoProvider"].AddSchema("bugInfo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Version")]
		[Bindable(true)]
		public string Version 
		{
			get { return GetColumnValue<string>(Columns.Version); }
			set { SetColumnValue(Columns.Version, value); }
		}
		  
		[XmlAttribute("BugNum")]
		[Bindable(true)]
		public string BugNum 
		{
			get { return GetColumnValue<string>(Columns.BugNum); }
			set { SetColumnValue(Columns.BugNum, value); }
		}
		  
		[XmlAttribute("BugStatus")]
		[Bindable(true)]
		public string BugStatus 
		{
			get { return GetColumnValue<string>(Columns.BugStatus); }
			set { SetColumnValue(Columns.BugStatus, value); }
		}
		  
		[XmlAttribute("DealMan")]
		[Bindable(true)]
		public string DealMan 
		{
			get { return GetColumnValue<string>(Columns.DealMan); }
			set { SetColumnValue(Columns.DealMan, value); }
		}
		  
		[XmlAttribute("CreatedTime")]
		[Bindable(true)]
		public DateTime CreatedTime 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedTime); }
			set { SetColumnValue(Columns.CreatedTime, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("Size")]
		[Bindable(true)]
		public int Size 
		{
			get { return GetColumnValue<int>(Columns.Size); }
			set { SetColumnValue(Columns.Size, value); }
		}
		  
		[XmlAttribute("Fired")]
		[Bindable(true)]
		public int Fired 
		{
			get { return GetColumnValue<int>(Columns.Fired); }
			set { SetColumnValue(Columns.Fired, value); }
		}
		  
		[XmlAttribute("TimeStamp")]
		[Bindable(true)]
		public DateTime TimeStamp 
		{
			get { return GetColumnValue<DateTime>(Columns.TimeStamp); }
			set { SetColumnValue(Columns.TimeStamp, value); }
		}
		  
		[XmlAttribute("Priority")]
		[Bindable(true)]
		public short Priority 
		{
			get { return GetColumnValue<short>(Columns.Priority); }
			set { SetColumnValue(Columns.Priority, value); }
		}
		  
		[XmlAttribute("HardLevel")]
		[Bindable(true)]
		public short HardLevel 
		{
			get { return GetColumnValue<short>(Columns.HardLevel); }
			set { SetColumnValue(Columns.HardLevel, value); }
		}
		  
		[XmlAttribute("LatestStartTime")]
		[Bindable(true)]
		public DateTime? LatestStartTime 
		{
			get { return GetColumnValue<DateTime?>(Columns.LatestStartTime); }
			set { SetColumnValue(Columns.LatestStartTime, value); }
		}
		  
		[XmlAttribute("Doc")]
		[Bindable(true)]
		public byte[] Doc 
		{
			get { return GetColumnValue<byte[]>(Columns.Doc); }
			set { SetColumnValue(Columns.Doc, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public DAL.ChangeLogCollection ChangeLogRecords()
		{
			return new DAL.ChangeLogCollection().Where(ChangeLog.Columns.BugNum, BugNum).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varVersion,string varBugNum,string varBugStatus,string varDealMan,DateTime varCreatedTime,string varDescription,int varSize,int varFired,DateTime varTimeStamp,short varPriority,short varHardLevel,DateTime? varLatestStartTime,byte[] varDoc)
		{
			BugInfo item = new BugInfo();
			
			item.Version = varVersion;
			
			item.BugNum = varBugNum;
			
			item.BugStatus = varBugStatus;
			
			item.DealMan = varDealMan;
			
			item.CreatedTime = varCreatedTime;
			
			item.Description = varDescription;
			
			item.Size = varSize;
			
			item.Fired = varFired;
			
			item.TimeStamp = varTimeStamp;
			
			item.Priority = varPriority;
			
			item.HardLevel = varHardLevel;
			
			item.LatestStartTime = varLatestStartTime;
			
			item.Doc = varDoc;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varVersion,string varBugNum,string varBugStatus,string varDealMan,DateTime varCreatedTime,string varDescription,int varSize,int varFired,DateTime varTimeStamp,short varPriority,short varHardLevel,DateTime? varLatestStartTime,byte[] varDoc)
		{
			BugInfo item = new BugInfo();
			
				item.Version = varVersion;
			
				item.BugNum = varBugNum;
			
				item.BugStatus = varBugStatus;
			
				item.DealMan = varDealMan;
			
				item.CreatedTime = varCreatedTime;
			
				item.Description = varDescription;
			
				item.Size = varSize;
			
				item.Fired = varFired;
			
				item.TimeStamp = varTimeStamp;
			
				item.Priority = varPriority;
			
				item.HardLevel = varHardLevel;
			
				item.LatestStartTime = varLatestStartTime;
			
				item.Doc = varDoc;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn VersionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BugNumColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BugStatusColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DealManColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedTimeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SizeColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FiredColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TimeStampColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn PriorityColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn HardLevelColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn LatestStartTimeColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DocColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Version = @"version";
			 public static string BugNum = @"bugNum";
			 public static string BugStatus = @"bugStatus";
			 public static string DealMan = @"dealMan";
			 public static string CreatedTime = @"createdTime";
			 public static string Description = @"description";
			 public static string Size = @"size";
			 public static string Fired = @"fired";
			 public static string TimeStamp = @"timeStamp";
			 public static string Priority = @"priority";
			 public static string HardLevel = @"hardLevel";
			 public static string LatestStartTime = @"latestStartTime";
			 public static string Doc = @"Doc";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
