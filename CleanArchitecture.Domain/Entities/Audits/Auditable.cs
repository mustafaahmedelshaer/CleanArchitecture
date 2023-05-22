using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Audits
{
    public abstract class Auditable : IAuditable
    {
        public Auditable()
        {
        }

        public Auditable(Auditable obj)
        {
            CreatedBy = obj.CreatedBy;
            CreatedOn = obj.CreatedOn;
            UpdatedBy = obj.UpdatedBy;
            UpdatedOn = obj.UpdatedOn;
            IsDeleted = obj.IsDeleted;
            Code = obj.Code;
        }


        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        [MaxLength(256)]
        public string? Code { get; set; }
     
        
        
        private string GenerateRandomCode(int iOTPLength)
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string sOTP = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < iOTPLength; i++)
            {
                string sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;
        }

    }
}
