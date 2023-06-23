using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LeVanTru0714.Models
{
    [Table("LVTSinhVien")]
    public class LVTSinhVien
    {
        [Key]
        public int LVTMaSinhVien {get; set;}
        public string LVTTenSinhVien {get; set;}
        public float LVTTuoi {get; set;}
    }
}