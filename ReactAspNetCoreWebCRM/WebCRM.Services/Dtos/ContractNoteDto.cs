using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractNoteDto : BaseDto<ContractNote>, IContractNote
    {
        public ContractNoteDto() { }

        public ContractNoteDto(ContractNote model)
        {
            this.SetModel(model);
        }

        public override void SetModel(ContractNote model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.NoteText = model.NoteText;
                this.ContractId = model.ContractId;
                this.UserId = model.UserId;

                if (model.User != null)
                {
                    this.User = new UserDto(model.User);
                }
            }
        }

        /// <summary>
        /// The id of the contract
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// The note text
        /// </summary>
        public string NoteText { get; set; } = string.Empty;
        
        /// <summary>
        /// The id of the user that created the note
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The dto of the user that created the note
        /// </summary>
        public UserDto User { get; set; } = new UserDto();

        public override ContractNote ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.NoteText = this.NoteText;
            model.ContractId = this.ContractId;
            model.UserId = this.UserId;

            return model;
        }
    }
}
