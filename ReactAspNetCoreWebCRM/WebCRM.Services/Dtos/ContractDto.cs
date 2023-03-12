using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    /// <summary>
    /// The Contract entity dto
    /// </summary>
    public class ContractDto : SoftDeletedDto<Contract>, IContract
    {
        public ContractDto()
        {
        }

        public ContractDto(Contract model) 
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
                    this.ContractPayments = model.ContractPayments.Select(x => new ContractPaymentDto(x)).ToList();
                }

                if (model.ContractMonthlyPayments != null && model.ContractMonthlyPayments.Any())
                {
                    this.ContractMonthlyPayments = model.ContractMonthlyPayments.Select(x => new ContractMonthlyPaymentDto(x)).ToList();
                }

                if (model.ContractCustomers != null && model.ContractCustomers.Any())
                {
                    this.ContractCustomers = model.ContractCustomers.Select(x => new ContractCustomerDto(x)).ToList();
                }

                if (model.ContractNotes != null && model.ContractNotes.Any())
                {
                    this.ContractNotes = model.ContractNotes.Select(x => new ContractNoteDto(x)).ToList();
                }
            }
        }

        /// <summary>
        /// The amount of the contract
        /// </summary>
        public decimal ContractAmount { get; set; }

        /// <summary>
        /// The date the contract ended
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The regular payment date
        /// </summary>
        public int PaymentDayOfTheMonth { get; set; }

        /// <summary>
        /// The regular payment amount
        /// </summary>
        public decimal RegularPaymentAmount { get; set; }

        /// <summary>
        /// The start date of the contract
        /// </summary>
        public DateTime StartDate { get; set; }

        private decimal? contractAmountPaid { get; set; }

        /// <summary>
        /// The amount of the contract that is paid
        /// </summary>
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

        /// <summary>
        /// The contract amount remaining
        /// </summary>
        public decimal ContractAmountRemaining
        {
            get
            {
                return Math.Max((this.ContractAmount - this.ContractAmountPaid), 0);
            }
        }

        /// <summary>
        /// The dtos matching the contract payments
        /// </summary>
        public List<ContractPaymentDto> ContractPayments { get; set; } = new List<ContractPaymentDto>();

        /// <summary>
        /// The Contract monthly payments
        /// </summary>
        public List<ContractMonthlyPaymentDto> ContractMonthlyPayments { get; set; } = new List<ContractMonthlyPaymentDto>();

        /// <summary>
        /// The dtos of the users associated with the contract
        /// </summary>
        public List<ContractCustomerDto> ContractCustomers { get; set; } = new List<ContractCustomerDto>();

        /// <summary>
        /// The notes associated with the contract
        /// </summary>
        public List<ContractNoteDto> ContractNotes { get; set; } = new List<ContractNoteDto>();

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
