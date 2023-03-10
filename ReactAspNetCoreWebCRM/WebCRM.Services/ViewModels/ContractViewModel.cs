using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractViewModel : SoftDeletedViewModel<Contract>, IContract
    {
        public ContractViewModel()
        {
        }

        public ContractViewModel(Contract model) 
        {
            this.SetModel(model);
        }

        public override void SetModel(Contract model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.ContractAmount = model.ContractAmount;
                this.EndDate = model.EndDate;
                this.StartDate = model.StartDate;
                this.PaymentDayOfTheMonth = model.PaymentDayOfTheMonth;
                this.RegularPaymentAmount = model.RegularPaymentAmount;

                if (model.ContractPayments != null && model.ContractPayments.Any())
                {
                    this.ContractPayments = model.ContractPayments.Select(x => new ContractPaymentViewModel(x)).ToList();
                }

                if (model.ContractMonthlyPayments != null && model.ContractMonthlyPayments.Any())
                {
                    this.ContractMonthlyPayments = model.ContractMonthlyPayments.Select(x => new ContractMonthlyPaymentViewModel(x)).ToList();
                }

                if (model.ContractCustomers != null && model.ContractCustomers.Any())
                {
                    this.ContractCustomers = model.ContractCustomers.Select(x => new ContractCustomerViewModel(x)).ToList();
                }

                if (model.ContractNotes != null && model.ContractNotes.Any())
                {
                    this.ContractNotes = model.ContractNotes.Select(x => new ContractNoteViewModel(x)).ToList();
                }
            }
        }

        public decimal ContractAmount { get; set; }
        public DateTime? EndDate { get; set; }
        public int PaymentDayOfTheMonth { get; set; }
        public decimal RegularPaymentAmount { get; set; }
        public DateTime StartDate { get; set; }

        private decimal? contractAmountPaid { get; set; }
        public decimal ContractAmountPaid 
        {
            get
            {
                if (contractAmountPaid.HasValue && contractAmountPaid.Value > 0)
                {
                    return contractAmountPaid.Value;
                }

                if (this.ContractPayments != null && this.ContractPayments.Any())
                {
                    this.contractAmountPaid = this.ContractPayments.Sum(x => x.PaymentAmount);
                    return this.contractAmountPaid.Value;
                }

                return 0m;
            }
        }

        public decimal ContractAmountRemaining
        {
            get
            {
                return Math.Max((this.ContractAmount - this.ContractAmountPaid), 0);
            }
        }

        public List<ContractPaymentViewModel> ContractPayments { get; set; } = new List<ContractPaymentViewModel>();

        public List<ContractMonthlyPaymentViewModel> ContractMonthlyPayments { get; set; } = new List<ContractMonthlyPaymentViewModel>();

        public List<ContractCustomerViewModel> ContractCustomers { get; set; } = new List<ContractCustomerViewModel>();

        public List<ContractNoteViewModel> ContractNotes { get; set; } = new List<ContractNoteViewModel>();

        public override Contract ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.ContractAmount = this.ContractAmount;
            model.EndDate = this.EndDate;
            model.StartDate = this.StartDate;
            model.PaymentDayOfTheMonth = this.PaymentDayOfTheMonth;
            model.RegularPaymentAmount = this.RegularPaymentAmount;

            return model;
        }
    }
}
