using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractPaymentDto : SoftDeletedDto<ContractPayment>, IContractPayment
    {
        public ContractPaymentDto() 
        {
        }

        public ContractPaymentDto(ContractPayment model)
        {
            this.SetModel(model);
        }

        public override void SetModel(ContractPayment model)
        {
            if (model != null) 
            {
                base.SetModel(model);
                this.ContractId = model.ContractId;
                this.ContractMonthlyPaymentId = model.ContractMonthlyPaymentId;
                this.PaymentAmount = model.PaymentAmount;
                this.EnteredByUserId = model.EnteredByUserId;

                if (model.Contract != null)
                {
                    this.Contract = new ContractDto(model.Contract);
                }

                if (model.EnteredByUser != null)
                {
                    this.EnteredByUser = new UserDto(model.EnteredByUser);
                }

                if (model.ContractMonthlyPayment != null) 
                {
                    this.ContractMonthlyPayment = new ContractMonthlyPaymentDto(model.ContractMonthlyPayment);
                }
            }
        }

        /// <summary>
        /// The id of the contract
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// The id of the contract monthly payment
        /// </summary>
        public int? ContractMonthlyPaymentId { get; set; }

        /// <summary>
        /// The id of the user who entered the payment
        /// </summary>
        public int EnteredByUserId { get; set; }

        /// <summary>
        /// The amount of the payment
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// The contract dto
        /// </summary>
        public ContractDto Contract { get; set; } = new ContractDto();

        /// <summary>
        /// The user dto
        /// </summary>
        public UserDto EnteredByUser { get; set; } = new UserDto();

        /// <summary>
        /// The contract monthly payment dto
        /// </summary>
        public ContractMonthlyPaymentDto ContractMonthlyPayment { get; set; } = new ContractMonthlyPaymentDto();

        public override ContractPayment ToBaseModel()
        {
            var model = base.ToBaseModel();

            model.ContractId = this.ContractId;
            model.ContractMonthlyPaymentId = this.ContractMonthlyPaymentId; 
            model.PaymentAmount = this.PaymentAmount;
            model.EnteredByUserId = this.EnteredByUserId;

            return model;
        }
    }
}
