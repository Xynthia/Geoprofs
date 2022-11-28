using System;
using System.ComponentModel.DataAnnotations;

namespace GeoprofsXyn.Models.UserViewModels
{
    public class VerlofDatumGroup
    {
        [DataType(DataType.Date)]
        public DateTime? VerlofBeginDatum { get; set; }
        public int VerlofCount { get; set; }
    }
}
