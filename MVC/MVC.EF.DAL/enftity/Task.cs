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
        [DisplayName("���")]
        public int TaskID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("����")]
        public string name { get; set; }

        [DisplayName("����")]
        public int passward { get; set; }

        [DisplayName("�Ƿ�ɾ��")]
        public int? isdelete { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("�Ա�")]
        public string sex { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [DisplayName("ʱ��")]
        public DateTime? tim { get; set; }

        [DisplayName("����")]
        public int age { get; set; }
    }
}
