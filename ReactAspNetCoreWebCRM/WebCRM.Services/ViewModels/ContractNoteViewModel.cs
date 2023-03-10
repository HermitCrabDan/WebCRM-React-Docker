using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractNoteViewModel : BaseViewModel<ContractNote>, IContractNote
    {
        public ContractNoteViewModel() { }

        public ContractNoteViewModel(ContractNote model)
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
                    this.User = new UserViewModel(model.User);
                }
            }
        }

        public int ContractId { get; set; }
        public string NoteText { get; set; } = string.Empty;
        public int UserId { get; set; }

        public UserViewModel User { get; set; } = new UserViewModel();

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
