namespace MVC.EF.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [DisplayName("编号")]
        public int TaskID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("姓名")]
        public string name { get; set; }

        [DisplayName("密码")]
        public int passward { get; set; }

        [DisplayName("是否删除")]
        public int? isdelete { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("性别")]
        public string sex { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [DisplayName("时间")]
        public DateTime? tim { get; set; }

        [DisplayName("年龄")]
        public int age { get; set; }
    }
}
