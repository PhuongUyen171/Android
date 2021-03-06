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

namespace WebAdmin.Models
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
    using System.ComponentModel.DataAnnotations;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MYPHAM")]
	public partial class ShopMyPhamDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCTHD(CTHD instance);
    partial void UpdateCTHD(CTHD instance);
    partial void DeleteCTHD(CTHD instance);
    partial void InsertSANPHAM(SANPHAM instance);
    partial void UpdateSANPHAM(SANPHAM instance);
    partial void DeleteSANPHAM(SANPHAM instance);
    partial void InsertHOADON(HOADON instance);
    partial void UpdateHOADON(HOADON instance);
    partial void DeleteHOADON(HOADON instance);
    partial void InsertKHACHHANG(KHACHHANG instance);
    partial void UpdateKHACHHANG(KHACHHANG instance);
    partial void DeleteKHACHHANG(KHACHHANG instance);
    partial void InsertLOAISP(LOAISP instance);
    partial void UpdateLOAISP(LOAISP instance);
    partial void DeleteLOAISP(LOAISP instance);
    partial void InsertNHANVIEN(NHANVIEN instance);
    partial void UpdateNHANVIEN(NHANVIEN instance);
    partial void DeleteNHANVIEN(NHANVIEN instance);
    #endregion
		
		public ShopMyPhamDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MYPHAMConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ShopMyPhamDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShopMyPhamDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShopMyPhamDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShopMyPhamDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CTHD> CTHDs
		{
			get
			{
				return this.GetTable<CTHD>();
			}
		}
		
		public System.Data.Linq.Table<SANPHAM> SANPHAMs
		{
			get
			{
				return this.GetTable<SANPHAM>();
			}
		}
		
		public System.Data.Linq.Table<HOADON> HOADONs
		{
			get
			{
				return this.GetTable<HOADON>();
			}
		}
		
		public System.Data.Linq.Table<KHACHHANG> KHACHHANGs
		{
			get
			{
				return this.GetTable<KHACHHANG>();
			}
		}
		
		public System.Data.Linq.Table<LOAISP> LOAISPs
		{
			get
			{
				return this.GetTable<LOAISP>();
			}
		}
		
		public System.Data.Linq.Table<NHANVIEN> NHANVIENs
		{
			get
			{
				return this.GetTable<NHANVIEN>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CTHD")]
	public partial class CTHD : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaHD;
		
		private int _MaSP;
		
		private System.Nullable<int> _DonGia;
		
		private System.Nullable<int> _SoLuong;
		
		private EntityRef<SANPHAM> _SANPHAM;
		
		private EntityRef<HOADON> _HOADON;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaHDChanging(int value);
    partial void OnMaHDChanged();
    partial void OnMaSPChanging(int value);
    partial void OnMaSPChanged();
    partial void OnDonGiaChanging(System.Nullable<int> value);
    partial void OnDonGiaChanged();
    partial void OnSoLuongChanging(System.Nullable<int> value);
    partial void OnSoLuongChanged();
    #endregion
		
		public CTHD()
		{
			this._SANPHAM = default(EntityRef<SANPHAM>);
			this._HOADON = default(EntityRef<HOADON>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHD", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MaHD
		{
			get
			{
				return this._MaHD;
			}
			set
			{
				if ((this._MaHD != value))
				{
					if (this._HOADON.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaHDChanging(value);
					this.SendPropertyChanging();
					this._MaHD = value;
					this.SendPropertyChanged("MaHD");
					this.OnMaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					if (this._SANPHAM.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonGia", DbType="Int")]
		public System.Nullable<int> DonGia
		{
			get
			{
				return this._DonGia;
			}
			set
			{
				if ((this._DonGia != value))
				{
					this.OnDonGiaChanging(value);
					this.SendPropertyChanging();
					this._DonGia = value;
					this.SendPropertyChanged("DonGia");
					this.OnDonGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int")]
		public System.Nullable<int> SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SANPHAM_CTHD", Storage="_SANPHAM", ThisKey="MaSP", OtherKey="MaSP", IsForeignKey=true)]
		public SANPHAM SANPHAM
		{
			get
			{
				return this._SANPHAM.Entity;
			}
			set
			{
				SANPHAM previousValue = this._SANPHAM.Entity;
				if (((previousValue != value) 
							|| (this._SANPHAM.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SANPHAM.Entity = null;
						previousValue.CTHDs.Remove(this);
					}
					this._SANPHAM.Entity = value;
					if ((value != null))
					{
						value.CTHDs.Add(this);
						this._MaSP = value.MaSP;
					}
					else
					{
						this._MaSP = default(int);
					}
					this.SendPropertyChanged("SANPHAM");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HOADON_CTHD", Storage="_HOADON", ThisKey="MaHD", OtherKey="MaHD", IsForeignKey=true)]
		public HOADON HOADON
		{
			get
			{
				return this._HOADON.Entity;
			}
			set
			{
				HOADON previousValue = this._HOADON.Entity;
				if (((previousValue != value) 
							|| (this._HOADON.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._HOADON.Entity = null;
						previousValue.CTHDs.Remove(this);
					}
					this._HOADON.Entity = value;
					if ((value != null))
					{
						value.CTHDs.Add(this);
						this._MaHD = value.MaHD;
					}
					else
					{
						this._MaHD = default(int);
					}
					this.SendPropertyChanged("HOADON");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SANPHAM")]
	public partial class SANPHAM : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaSP;
		
		private string _TenSP;
		
		private System.Nullable<int> _SoLuong;
		
		private System.Nullable<int> _GiaBan;
		
		private System.Nullable<int> _GiaVon;
		
		private System.Nullable<bool> _TrangThai;
		
		private string _HinhAnh;
		
		private System.Nullable<int> _MaLoai;
		
		private string _MoTa;
		
		private string _DonViTinh;
		
		private EntitySet<CTHD> _CTHDs;
		
		private EntityRef<LOAISP> _LOAISP;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaSPChanging(int value);
    partial void OnMaSPChanged();
    partial void OnTenSPChanging(string value);
    partial void OnTenSPChanged();
    partial void OnSoLuongChanging(System.Nullable<int> value);
    partial void OnSoLuongChanged();
    partial void OnGiaBanChanging(System.Nullable<int> value);
    partial void OnGiaBanChanged();
    partial void OnGiaVonChanging(System.Nullable<int> value);
    partial void OnGiaVonChanged();
    partial void OnTrangThaiChanging(System.Nullable<bool> value);
    partial void OnTrangThaiChanged();
    partial void OnHinhAnhChanging(string value);
    partial void OnHinhAnhChanged();
    partial void OnMaLoaiChanging(System.Nullable<int> value);
    partial void OnMaLoaiChanged();
    partial void OnMoTaChanging(string value);
    partial void OnMoTaChanged();
    partial void OnDonViTinhChanging(string value);
    partial void OnDonViTinhChanged();
    #endregion
		
		public SANPHAM()
		{
			this._CTHDs = new EntitySet<CTHD>(new Action<CTHD>(this.attach_CTHDs), new Action<CTHD>(this.detach_CTHDs));
			this._LOAISP = default(EntityRef<LOAISP>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenSP", DbType="NVarChar(MAX)")]
		public string TenSP
		{
			get
			{
				return this._TenSP;
			}
			set
			{
				if ((this._TenSP != value))
				{
					this.OnTenSPChanging(value);
					this.SendPropertyChanging();
					this._TenSP = value;
					this.SendPropertyChanged("TenSP");
					this.OnTenSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int")]
		public System.Nullable<int> SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiaBan", DbType="Int")]
		public System.Nullable<int> GiaBan
		{
			get
			{
				return this._GiaBan;
			}
			set
			{
				if ((this._GiaBan != value))
				{
					this.OnGiaBanChanging(value);
					this.SendPropertyChanging();
					this._GiaBan = value;
					this.SendPropertyChanged("GiaBan");
					this.OnGiaBanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiaVon", DbType="Int")]
		public System.Nullable<int> GiaVon
		{
			get
			{
				return this._GiaVon;
			}
			set
			{
				if ((this._GiaVon != value))
				{
					this.OnGiaVonChanging(value);
					this.SendPropertyChanging();
					this._GiaVon = value;
					this.SendPropertyChanged("GiaVon");
					this.OnGiaVonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="Bit")]
		public System.Nullable<bool> TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HinhAnh", DbType="VarChar(MAX)")]
		public string HinhAnh
		{
			get
			{
				return this._HinhAnh;
			}
			set
			{
				if ((this._HinhAnh != value))
				{
					this.OnHinhAnhChanging(value);
					this.SendPropertyChanging();
					this._HinhAnh = value;
					this.SendPropertyChanged("HinhAnh");
					this.OnHinhAnhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaLoai", DbType="Int")]
		public System.Nullable<int> MaLoai
		{
			get
			{
				return this._MaLoai;
			}
			set
			{
				if ((this._MaLoai != value))
				{
					if (this._LOAISP.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaLoaiChanging(value);
					this.SendPropertyChanging();
					this._MaLoai = value;
					this.SendPropertyChanged("MaLoai");
					this.OnMaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoTa", DbType="NVarChar(MAX)")]
		public string MoTa
		{
			get
			{
				return this._MoTa;
			}
			set
			{
				if ((this._MoTa != value))
				{
					this.OnMoTaChanging(value);
					this.SendPropertyChanging();
					this._MoTa = value;
					this.SendPropertyChanged("MoTa");
					this.OnMoTaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonViTinh", DbType="NVarChar(50)")]
		public string DonViTinh
		{
			get
			{
				return this._DonViTinh;
			}
			set
			{
				if ((this._DonViTinh != value))
				{
					this.OnDonViTinhChanging(value);
					this.SendPropertyChanging();
					this._DonViTinh = value;
					this.SendPropertyChanged("DonViTinh");
					this.OnDonViTinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SANPHAM_CTHD", Storage="_CTHDs", ThisKey="MaSP", OtherKey="MaSP")]
		public EntitySet<CTHD> CTHDs
		{
			get
			{
				return this._CTHDs;
			}
			set
			{
				this._CTHDs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LOAISP_SANPHAM", Storage="_LOAISP", ThisKey="MaLoai", OtherKey="MaLoaiSP", IsForeignKey=true)]
		public LOAISP LOAISP
		{
			get
			{
				return this._LOAISP.Entity;
			}
			set
			{
				LOAISP previousValue = this._LOAISP.Entity;
				if (((previousValue != value) 
							|| (this._LOAISP.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LOAISP.Entity = null;
						previousValue.SANPHAMs.Remove(this);
					}
					this._LOAISP.Entity = value;
					if ((value != null))
					{
						value.SANPHAMs.Add(this);
						this._MaLoai = value.MaLoaiSP;
					}
					else
					{
						this._MaLoai = default(Nullable<int>);
					}
					this.SendPropertyChanged("LOAISP");
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
		
		private void attach_CTHDs(CTHD entity)
		{
			this.SendPropertyChanging();
			entity.SANPHAM = this;
		}
		
		private void detach_CTHDs(CTHD entity)
		{
			this.SendPropertyChanging();
			entity.SANPHAM = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HOADON")]
	public partial class HOADON : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaHD;
		
		private System.Nullable<System.DateTime> _NgayLap;
		
		private System.Nullable<System.DateTime> _NgayGiao;
		
		private string _DiaChiGiao;
		
		private System.Nullable<int> _MaKH;
		
		private System.Nullable<bool> _TrangThai;
		
		private System.Nullable<int> _TongTien;
		
		private System.Nullable<int> _TongSP;
		
		private EntitySet<CTHD> _CTHDs;
		
		private EntityRef<KHACHHANG> _KHACHHANG;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaHDChanging(int value);
    partial void OnMaHDChanged();
    partial void OnNgayLapChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayLapChanged();
    partial void OnNgayGiaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayGiaoChanged();
    partial void OnDiaChiGiaoChanging(string value);
    partial void OnDiaChiGiaoChanged();
    partial void OnMaKHChanging(System.Nullable<int> value);
    partial void OnMaKHChanged();
    partial void OnTrangThaiChanging(System.Nullable<bool> value);
    partial void OnTrangThaiChanged();
    partial void OnTongTienChanging(System.Nullable<int> value);
    partial void OnTongTienChanged();
    partial void OnTongSPChanging(System.Nullable<int> value);
    partial void OnTongSPChanged();
    #endregion
		
		public HOADON()
		{
			this._CTHDs = new EntitySet<CTHD>(new Action<CTHD>(this.attach_CTHDs), new Action<CTHD>(this.detach_CTHDs));
			this._KHACHHANG = default(EntityRef<KHACHHANG>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHD", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaHD
		{
			get
			{
				return this._MaHD;
			}
			set
			{
				if ((this._MaHD != value))
				{
					this.OnMaHDChanging(value);
					this.SendPropertyChanging();
					this._MaHD = value;
					this.SendPropertyChanged("MaHD");
					this.OnMaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayLap", DbType="Date")]
		public System.Nullable<System.DateTime> NgayLap
		{
			get
			{
				return this._NgayLap;
			}
			set
			{
				if ((this._NgayLap != value))
				{
					this.OnNgayLapChanging(value);
					this.SendPropertyChanging();
					this._NgayLap = value;
					this.SendPropertyChanged("NgayLap");
					this.OnNgayLapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayGiao", DbType="Date")]
		public System.Nullable<System.DateTime> NgayGiao
		{
			get
			{
				return this._NgayGiao;
			}
			set
			{
				if ((this._NgayGiao != value))
				{
					this.OnNgayGiaoChanging(value);
					this.SendPropertyChanging();
					this._NgayGiao = value;
					this.SendPropertyChanged("NgayGiao");
					this.OnNgayGiaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChiGiao", DbType="NVarChar(MAX)")]
		public string DiaChiGiao
		{
			get
			{
				return this._DiaChiGiao;
			}
			set
			{
				if ((this._DiaChiGiao != value))
				{
					this.OnDiaChiGiaoChanging(value);
					this.SendPropertyChanging();
					this._DiaChiGiao = value;
					this.SendPropertyChanged("DiaChiGiao");
					this.OnDiaChiGiaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKH", DbType="Int")]
		public System.Nullable<int> MaKH
		{
			get
			{
				return this._MaKH;
			}
			set
			{
				if ((this._MaKH != value))
				{
					if (this._KHACHHANG.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaKHChanging(value);
					this.SendPropertyChanging();
					this._MaKH = value;
					this.SendPropertyChanged("MaKH");
					this.OnMaKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="Bit")]
		public System.Nullable<bool> TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongTien", DbType="Int")]
		public System.Nullable<int> TongTien
		{
			get
			{
				return this._TongTien;
			}
			set
			{
				if ((this._TongTien != value))
				{
					this.OnTongTienChanging(value);
					this.SendPropertyChanging();
					this._TongTien = value;
					this.SendPropertyChanged("TongTien");
					this.OnTongTienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongSP", DbType="Int")]
		public System.Nullable<int> TongSP
		{
			get
			{
				return this._TongSP;
			}
			set
			{
				if ((this._TongSP != value))
				{
					this.OnTongSPChanging(value);
					this.SendPropertyChanging();
					this._TongSP = value;
					this.SendPropertyChanged("TongSP");
					this.OnTongSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HOADON_CTHD", Storage="_CTHDs", ThisKey="MaHD", OtherKey="MaHD")]
		public EntitySet<CTHD> CTHDs
		{
			get
			{
				return this._CTHDs;
			}
			set
			{
				this._CTHDs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KHACHHANG_HOADON", Storage="_KHACHHANG", ThisKey="MaKH", OtherKey="MaKH", IsForeignKey=true)]
		public KHACHHANG KHACHHANG
		{
			get
			{
				return this._KHACHHANG.Entity;
			}
			set
			{
				KHACHHANG previousValue = this._KHACHHANG.Entity;
				if (((previousValue != value) 
							|| (this._KHACHHANG.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KHACHHANG.Entity = null;
						previousValue.HOADONs.Remove(this);
					}
					this._KHACHHANG.Entity = value;
					if ((value != null))
					{
						value.HOADONs.Add(this);
						this._MaKH = value.MaKH;
					}
					else
					{
						this._MaKH = default(Nullable<int>);
					}
					this.SendPropertyChanged("KHACHHANG");
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
		
		private void attach_CTHDs(CTHD entity)
		{
			this.SendPropertyChanging();
			entity.HOADON = this;
		}
		
		private void detach_CTHDs(CTHD entity)
		{
			this.SendPropertyChanging();
			entity.HOADON = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KHACHHANG")]
	public partial class KHACHHANG : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaKH;
		
		private string _TenKH;
		
		private string _Email;
		
		private string _MatKhau;
		
		private string _SDT;
		
		private string _DiaChi;
		
		private EntitySet<HOADON> _HOADONs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaKHChanging(int value);
    partial void OnMaKHChanged();
    partial void OnTenKHChanging(string value);
    partial void OnTenKHChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    #endregion
		
		public KHACHHANG()
		{
			this._HOADONs = new EntitySet<HOADON>(new Action<HOADON>(this.attach_HOADONs), new Action<HOADON>(this.detach_HOADONs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaKH", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaKH
		{
			get
			{
				return this._MaKH;
			}
			set
			{
				if ((this._MaKH != value))
				{
					this.OnMaKHChanging(value);
					this.SendPropertyChanging();
					this._MaKH = value;
					this.SendPropertyChanged("MaKH");
					this.OnMaKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenKH", DbType="NVarChar(MAX)")]
		public string TenKH
		{
			get
			{
				return this._TenKH;
			}
			set
			{
				if ((this._TenKH != value))
				{
					this.OnTenKHChanging(value);
					this.SendPropertyChanging();
					this._TenKH = value;
					this.SendPropertyChanged("TenKH");
					this.OnTenKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(MAX)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="VarChar(MAX)")]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="Char(11)")]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(MAX)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KHACHHANG_HOADON", Storage="_HOADONs", ThisKey="MaKH", OtherKey="MaKH")]
		public EntitySet<HOADON> HOADONs
		{
			get
			{
				return this._HOADONs;
			}
			set
			{
				this._HOADONs.Assign(value);
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
		
		private void attach_HOADONs(HOADON entity)
		{
			this.SendPropertyChanging();
			entity.KHACHHANG = this;
		}
		
		private void detach_HOADONs(HOADON entity)
		{
			this.SendPropertyChanging();
			entity.KHACHHANG = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LOAISP")]
	public partial class LOAISP : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MaLoaiSP;
		
		private string _TenLoaiSP;
		
		private string _HinhAnh;
		
		private EntitySet<SANPHAM> _SANPHAMs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaLoaiSPChanging(int value);
    partial void OnMaLoaiSPChanged();
    partial void OnTenLoaiSPChanging(string value);
    partial void OnTenLoaiSPChanged();
    partial void OnHinhAnhChanging(string value);
    partial void OnHinhAnhChanged();
    #endregion
		
		public LOAISP()
		{
			this._SANPHAMs = new EntitySet<SANPHAM>(new Action<SANPHAM>(this.attach_SANPHAMs), new Action<SANPHAM>(this.detach_SANPHAMs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaLoaiSP", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MaLoaiSP
		{
			get
			{
				return this._MaLoaiSP;
			}
			set
			{
				if ((this._MaLoaiSP != value))
				{
					this.OnMaLoaiSPChanging(value);
					this.SendPropertyChanging();
					this._MaLoaiSP = value;
					this.SendPropertyChanged("MaLoaiSP");
					this.OnMaLoaiSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenLoaiSP", DbType="NVarChar(MAX)")]
		public string TenLoaiSP
		{
			get
			{
				return this._TenLoaiSP;
			}
			set
			{
				if ((this._TenLoaiSP != value))
				{
					this.OnTenLoaiSPChanging(value);
					this.SendPropertyChanging();
					this._TenLoaiSP = value;
					this.SendPropertyChanged("TenLoaiSP");
					this.OnTenLoaiSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HinhAnh", DbType="VarChar(MAX)")]
		public string HinhAnh
		{
			get
			{
				return this._HinhAnh;
			}
			set
			{
				if ((this._HinhAnh != value))
				{
					this.OnHinhAnhChanging(value);
					this.SendPropertyChanging();
					this._HinhAnh = value;
					this.SendPropertyChanged("HinhAnh");
					this.OnHinhAnhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LOAISP_SANPHAM", Storage="_SANPHAMs", ThisKey="MaLoaiSP", OtherKey="MaLoai")]
		public EntitySet<SANPHAM> SANPHAMs
		{
			get
			{
				return this._SANPHAMs;
			}
			set
			{
				this._SANPHAMs.Assign(value);
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
		
		private void attach_SANPHAMs(SANPHAM entity)
		{
			this.SendPropertyChanging();
			entity.LOAISP = this;
		}
		
		private void detach_SANPHAMs(SANPHAM entity)
		{
			this.SendPropertyChanging();
			entity.LOAISP = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NHANVIEN")]
	public partial class NHANVIEN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _TaiKhoan;
		
		private string _MatKhau;
		
		private string _TenNV;
		
		private bool _Quyen;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTaiKhoanChanging(string value);
    partial void OnTaiKhoanChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    partial void OnTenNVChanging(string value);
    partial void OnTenNVChanged();
    partial void OnQuyenChanging(bool value);
    partial void OnQuyenChanged();
    #endregion
		
		public NHANVIEN()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaiKhoan", DbType="VarChar(200) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string TaiKhoan
		{
			get
			{
				return this._TaiKhoan;
			}
			set
			{
				if ((this._TaiKhoan != value))
				{
					this.OnTaiKhoanChanging(value);
					this.SendPropertyChanging();
					this._TaiKhoan = value;
					this.SendPropertyChanged("TaiKhoan");
					this.OnTaiKhoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="VarChar(MAX)")]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNV", DbType="NVarChar(MAX)")]
		//[Required(AllowEmptyStrings = false, ErrorMessage = "Tên nhân viên không được để trống. ")]
		public string TenNV
		{
			get
			{
				return this._TenNV;
			}
			set
			{
				if ((this._TenNV != value))
				{
					this.OnTenNVChanging(value);
					this.SendPropertyChanging();
					this._TenNV = value;
					this.SendPropertyChanged("TenNV");
					this.OnTenNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quyen", DbType="Bit NOT NULL")]
		public bool Quyen
		{
			get
			{
				return this._Quyen;
			}
			set
			{
				if ((this._Quyen != value))
				{
					this.OnQuyenChanging(value);
					this.SendPropertyChanging();
					this._Quyen = value;
					this.SendPropertyChanged("Quyen");
					this.OnQuyenChanged();
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
