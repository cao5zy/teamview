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
	/// Strongly-typed collection for the KeyInfo class.
	/// </summary>
    [Serializable]
	public partial class KeyInfoCollection : ActiveList<KeyInfo, KeyInfoCollection>
	{	   
		public KeyInfoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>KeyInfoCollection</returns>
		public KeyInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                KeyInfo o = this[i];
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
	/// This is an ActiveRecord class which wraps the keyInfo table.
	/// </summary>
	[Serializable]
	public partial class KeyInfo : ActiveRecord<KeyInfo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public KeyInfo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public KeyInfo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public KeyInfo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public KeyInfo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("keyInfo", TableType.Table, DataService.GetInstance("BugInfoProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarKeyName = new TableSchema.TableColumn(schema);
				colvarKeyName.ColumnName = "keyName";
				colvarKeyName.DataType = DbType.String;
				colvarKeyName.MaxLength = 10;
				colvarKeyName.AutoIncrement = false;
				colvarKeyName.IsNullable = false;
				colvarKeyName.IsPrimaryKey = true;
				colvarKeyName.IsForeignKey = false;
				colvarKeyName.IsReadOnly = false;
				colvarKeyName.DefaultSetting = @"";
				colvarKeyName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKeyName);
				
				TableSchema.TableColumn colvarNum = new TableSchema.TableColumn(schema);
				colvarNum.ColumnName = "num";
				colvarNum.DataType = DbType.Int64;
				colvarNum.MaxLength = 0;
				colvarNum.AutoIncrement = false;
				colvarNum.IsNullable = false;
				colvarNum.IsPrimaryKey = false;
				colvarNum.IsForeignKey = false;
				colvarNum.IsReadOnly = false;
				colvarNum.DefaultSetting = @"";
				colvarNum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNum);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["BugInfoProvider"].AddSchema("keyInfo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("KeyName")]
		[Bindable(true)]
		public string KeyName 
		{
			get { return GetColumnValue<string>(Columns.KeyName); }
			set { SetColumnValue(Columns.KeyName, value); }
		}
		  
		[XmlAttribute("Num")]
		[Bindable(true)]
		public long Num 
		{
			get { return GetColumnValue<long>(Columns.Num); }
			set { SetColumnValue(Columns.Num, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varKeyName,long varNum)
		{
			KeyInfo item = new KeyInfo();
			
			item.KeyName = varKeyName;
			
			item.Num = varNum;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varKeyName,long varNum)
		{
			KeyInfo item = new KeyInfo();
			
				item.KeyName = varKeyName;
			
				item.Num = varNum;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn KeyNameColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NumColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string KeyName = @"keyName";
			 public static string Num = @"num";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}