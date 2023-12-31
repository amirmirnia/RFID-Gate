﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace salmanzadehcart
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="salmanzadehclub")]
	public partial class DatasalmanzadehlinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTableinsert(Tableinsert instance);
    partial void UpdateTableinsert(Tableinsert instance);
    partial void DeleteTableinsert(Tableinsert instance);
    #endregion
		
		public DatasalmanzadehlinqDataContext() : 
				base(global::salmanzadehcart.Properties.Settings.Default.salmanzadehclubConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DatasalmanzadehlinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatasalmanzadehlinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatasalmanzadehlinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatasalmanzadehlinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Tableinsert> Tableinserts
		{
			get
			{
				return this.GetTable<Tableinsert>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tableinsert")]
	public partial class Tableinsert : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _firstname;
		
		private string _lastname;
		
		private string _fame;
		
		private string _typeclass;
		
		private string _Nickname;
		
		private string _post;
		
		private string _Training;
		
		private string _timeclass;
		
		private string _job;
		
		private System.Nullable<int> _active;
		
		private string _datalogin;
		
		private System.Nullable<int> _Weight;
		
		private string _imge;
		
		private System.Nullable<int> _hight;
		
		private string _Facilities;
		
		private string _Degree;
		
		private string _Blood;
		
		private string _Eye;
		
		private string _note;
		
		private string _Records;
		
		private System.Nullable<int> _num;
		
		private System.Nullable<int> _card;
		
		private string _mony;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnfirstnameChanging(string value);
    partial void OnfirstnameChanged();
    partial void OnlastnameChanging(string value);
    partial void OnlastnameChanged();
    partial void OnfameChanging(string value);
    partial void OnfameChanged();
    partial void OntypeclassChanging(string value);
    partial void OntypeclassChanged();
    partial void OnNicknameChanging(string value);
    partial void OnNicknameChanged();
    partial void OnpostChanging(string value);
    partial void OnpostChanged();
    partial void OnTrainingChanging(string value);
    partial void OnTrainingChanged();
    partial void OntimeclassChanging(string value);
    partial void OntimeclassChanged();
    partial void OnjobChanging(string value);
    partial void OnjobChanged();
    partial void OnactiveChanging(System.Nullable<int> value);
    partial void OnactiveChanged();
    partial void OndataloginChanging(string value);
    partial void OndataloginChanged();
    partial void OnWeightChanging(System.Nullable<int> value);
    partial void OnWeightChanged();
    partial void OnimgeChanging(string value);
    partial void OnimgeChanged();
    partial void OnhightChanging(System.Nullable<int> value);
    partial void OnhightChanged();
    partial void OnFacilitiesChanging(string value);
    partial void OnFacilitiesChanged();
    partial void OnDegreeChanging(string value);
    partial void OnDegreeChanged();
    partial void OnBloodChanging(string value);
    partial void OnBloodChanged();
    partial void OnEyeChanging(string value);
    partial void OnEyeChanged();
    partial void OnnoteChanging(string value);
    partial void OnnoteChanged();
    partial void OnRecordsChanging(string value);
    partial void OnRecordsChanged();
    partial void OnnumChanging(System.Nullable<int> value);
    partial void OnnumChanged();
    partial void OncardChanging(System.Nullable<int> value);
    partial void OncardChanged();
    partial void OnmonyChanging(string value);
    partial void OnmonyChanged();
    #endregion
		
		public Tableinsert()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstname", DbType="NVarChar(MAX)")]
		public string firstname
		{
			get
			{
				return this._firstname;
			}
			set
			{
				if ((this._firstname != value))
				{
					this.OnfirstnameChanging(value);
					this.SendPropertyChanging();
					this._firstname = value;
					this.SendPropertyChanged("firstname");
					this.OnfirstnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastname", DbType="NVarChar(MAX)")]
		public string lastname
		{
			get
			{
				return this._lastname;
			}
			set
			{
				if ((this._lastname != value))
				{
					this.OnlastnameChanging(value);
					this.SendPropertyChanging();
					this._lastname = value;
					this.SendPropertyChanged("lastname");
					this.OnlastnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fame", DbType="NVarChar(MAX)")]
		public string fame
		{
			get
			{
				return this._fame;
			}
			set
			{
				if ((this._fame != value))
				{
					this.OnfameChanging(value);
					this.SendPropertyChanging();
					this._fame = value;
					this.SendPropertyChanged("fame");
					this.OnfameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_typeclass", DbType="NVarChar(MAX)")]
		public string typeclass
		{
			get
			{
				return this._typeclass;
			}
			set
			{
				if ((this._typeclass != value))
				{
					this.OntypeclassChanging(value);
					this.SendPropertyChanging();
					this._typeclass = value;
					this.SendPropertyChanged("typeclass");
					this.OntypeclassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nickname", DbType="NVarChar(MAX)")]
		public string Nickname
		{
			get
			{
				return this._Nickname;
			}
			set
			{
				if ((this._Nickname != value))
				{
					this.OnNicknameChanging(value);
					this.SendPropertyChanging();
					this._Nickname = value;
					this.SendPropertyChanged("Nickname");
					this.OnNicknameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_post", DbType="NVarChar(MAX)")]
		public string post
		{
			get
			{
				return this._post;
			}
			set
			{
				if ((this._post != value))
				{
					this.OnpostChanging(value);
					this.SendPropertyChanging();
					this._post = value;
					this.SendPropertyChanged("post");
					this.OnpostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Training", DbType="NVarChar(MAX)")]
		public string Training
		{
			get
			{
				return this._Training;
			}
			set
			{
				if ((this._Training != value))
				{
					this.OnTrainingChanging(value);
					this.SendPropertyChanging();
					this._Training = value;
					this.SendPropertyChanged("Training");
					this.OnTrainingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_timeclass", DbType="NVarChar(MAX)")]
		public string timeclass
		{
			get
			{
				return this._timeclass;
			}
			set
			{
				if ((this._timeclass != value))
				{
					this.OntimeclassChanging(value);
					this.SendPropertyChanging();
					this._timeclass = value;
					this.SendPropertyChanged("timeclass");
					this.OntimeclassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_job", DbType="NVarChar(MAX)")]
		public string job
		{
			get
			{
				return this._job;
			}
			set
			{
				if ((this._job != value))
				{
					this.OnjobChanging(value);
					this.SendPropertyChanging();
					this._job = value;
					this.SendPropertyChanged("job");
					this.OnjobChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_active", DbType="Int")]
		public System.Nullable<int> active
		{
			get
			{
				return this._active;
			}
			set
			{
				if ((this._active != value))
				{
					this.OnactiveChanging(value);
					this.SendPropertyChanging();
					this._active = value;
					this.SendPropertyChanged("active");
					this.OnactiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datalogin", DbType="NVarChar(MAX)")]
		public string datalogin
		{
			get
			{
				return this._datalogin;
			}
			set
			{
				if ((this._datalogin != value))
				{
					this.OndataloginChanging(value);
					this.SendPropertyChanging();
					this._datalogin = value;
					this.SendPropertyChanged("datalogin");
					this.OndataloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weight", DbType="Int")]
		public System.Nullable<int> Weight
		{
			get
			{
				return this._Weight;
			}
			set
			{
				if ((this._Weight != value))
				{
					this.OnWeightChanging(value);
					this.SendPropertyChanging();
					this._Weight = value;
					this.SendPropertyChanged("Weight");
					this.OnWeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_imge", DbType="NVarChar(MAX)")]
		public string imge
		{
			get
			{
				return this._imge;
			}
			set
			{
				if ((this._imge != value))
				{
					this.OnimgeChanging(value);
					this.SendPropertyChanging();
					this._imge = value;
					this.SendPropertyChanged("imge");
					this.OnimgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hight", DbType="Int")]
		public System.Nullable<int> hight
		{
			get
			{
				return this._hight;
			}
			set
			{
				if ((this._hight != value))
				{
					this.OnhightChanging(value);
					this.SendPropertyChanging();
					this._hight = value;
					this.SendPropertyChanged("hight");
					this.OnhightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Facilities", DbType="NVarChar(MAX)")]
		public string Facilities
		{
			get
			{
				return this._Facilities;
			}
			set
			{
				if ((this._Facilities != value))
				{
					this.OnFacilitiesChanging(value);
					this.SendPropertyChanging();
					this._Facilities = value;
					this.SendPropertyChanged("Facilities");
					this.OnFacilitiesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Degree", DbType="NVarChar(MAX)")]
		public string Degree
		{
			get
			{
				return this._Degree;
			}
			set
			{
				if ((this._Degree != value))
				{
					this.OnDegreeChanging(value);
					this.SendPropertyChanging();
					this._Degree = value;
					this.SendPropertyChanged("Degree");
					this.OnDegreeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Blood", DbType="NVarChar(MAX)")]
		public string Blood
		{
			get
			{
				return this._Blood;
			}
			set
			{
				if ((this._Blood != value))
				{
					this.OnBloodChanging(value);
					this.SendPropertyChanging();
					this._Blood = value;
					this.SendPropertyChanged("Blood");
					this.OnBloodChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Eye", DbType="NVarChar(MAX)")]
		public string Eye
		{
			get
			{
				return this._Eye;
			}
			set
			{
				if ((this._Eye != value))
				{
					this.OnEyeChanging(value);
					this.SendPropertyChanging();
					this._Eye = value;
					this.SendPropertyChanged("Eye");
					this.OnEyeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_note", DbType="NVarChar(MAX)")]
		public string note
		{
			get
			{
				return this._note;
			}
			set
			{
				if ((this._note != value))
				{
					this.OnnoteChanging(value);
					this.SendPropertyChanging();
					this._note = value;
					this.SendPropertyChanged("note");
					this.OnnoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Records", DbType="NVarChar(MAX)")]
		public string Records
		{
			get
			{
				return this._Records;
			}
			set
			{
				if ((this._Records != value))
				{
					this.OnRecordsChanging(value);
					this.SendPropertyChanging();
					this._Records = value;
					this.SendPropertyChanged("Records");
					this.OnRecordsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_num", DbType="Int")]
		public System.Nullable<int> num
		{
			get
			{
				return this._num;
			}
			set
			{
				if ((this._num != value))
				{
					this.OnnumChanging(value);
					this.SendPropertyChanging();
					this._num = value;
					this.SendPropertyChanged("num");
					this.OnnumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_card", DbType="Int")]
		public System.Nullable<int> card
		{
			get
			{
				return this._card;
			}
			set
			{
				if ((this._card != value))
				{
					this.OncardChanging(value);
					this.SendPropertyChanging();
					this._card = value;
					this.SendPropertyChanged("card");
					this.OncardChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mony", DbType="NVarChar(50)")]
		public string mony
		{
			get
			{
				return this._mony;
			}
			set
			{
				if ((this._mony != value))
				{
					this.OnmonyChanging(value);
					this.SendPropertyChanging();
					this._mony = value;
					this.SendPropertyChanged("mony");
					this.OnmonyChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
