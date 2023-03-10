using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Models
{
    public class ContractCustomerDto : SoftDeletedDto<ContractCustomer>, IContractCustomer
    {
        public ContractCustomerDto() { }

        public ContractCustomerDto(ContractCustomer model)
        {
            this.SetModel(model);
        }

        public override void SetModel(ContractCustomer model)
        {
            if (model != null)
            {
                base.SetModel(model);
                this.ContractId = model.ContractId;
                this.CustomerId = model.CustomerId;

                if (model.Customer != null)
                {
                    this.Customer = new UserDto(model.Customer);
                }

                if (model.Contract != null) 
                {
                    this.Contract = new ContractDto(model.Contract);
                }
            }
        }

        /// <summary>
        /// The Id of the contract
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// The Id of the customer
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The Contract dto
        /// </summary>
        public ContractDto Contract { get; set; } = new ContractDto();

        /// <summary>
        /// The Customer dto
        /// </summary>
        public UserDto Customer { get; set; } = new UserDto();

        public override ContractCustomer ToBaseModel()
        {
            var model = base.ToBaseModel();
            model.ContractId = this.ContractId;
            model.CustomerId = this.CustomerId;
            return model;
        }
    }
}
