﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HopDong
    {
        [Display(Name = "Mã Hợp Đồng")]
        public int IdHD { get; set; }
        [Required(ErrorMessage = "Vui lòng không bỏ trống trường này")]
        [Display(Name = "Mã Nhân Viên")]
        public Nullable<int> IdNV { get; set; }
        [Display(Name = "Loại Hợp Đồng")]
        [Required(ErrorMessage = "Vui lòng không bỏ trống trường này")]
        public string LoaiHD { get; set; }
        [Display(Name = "Từ Ngày")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng không bỏ trống trường này")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> TuNgay { get; set; }
        [Display(Name = "Đến Ngày")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng không bỏ trống trường này")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DenNgay { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
