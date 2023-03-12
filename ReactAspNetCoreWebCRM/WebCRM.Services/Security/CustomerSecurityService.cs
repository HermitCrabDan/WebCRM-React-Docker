using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRM.Data;

namespace WebCRM.Services.Security
{
    public class CustomerSecurityService : ICustomerSecurityService
    {
        private readonly IRepository<User> _userRepository;
        public CustomerSecurityService(IRepository<User> userRepository) 
        {
            this._userRepository = userRepository;
        }

        /// <summary>
        /// Checks if the customer can view the specific entity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="userId">the user id</param>
        /// <param name="entityId">the entity id</param>
        /// <returns>A boolean value of true or false</returns>
        public async Task<bool> CanCustomerViewEntityAsync<TEntity>(int userId, int entityId) 
            where TEntity : class, IDataModel<TEntity>, new()
        {
            var entityName = typeof(TEntity).Name;
            bool canView = false;

            switch (entityName) 
            {
                case nameof(Contract):
                    canView = await canCustomerViewContractAsync(userId, entityId);
                    break;

                case nameof(ContractPayment):
                    canView = await canCustomerViewPaymentAsync(userId, entityId);
                    break;

                case nameof(ContractMonthlyPayment):
                    canView = await canCustomerViewMonthlyPaymentAsync(userId, entityId);
                    break;
            }

            return canView;
        }

        private async Task<bool> canCustomerViewContractAsync(int userId, int entityId)
        {
            return await this._userRepository.RepositoryTable
                .AnyAsync(x => x.Id == userId 
                    && x.ContractCustomers.Any(y => y.ContractId == entityId));
        }

        private async Task<bool> canCustomerViewPaymentAsync(int userId, int entityId)
        {
            return await this._userRepository.RepositoryTable
                .AnyAsync(x => x.Id == userId
                    && x.ContractCustomers.Any(y => y.Contract.ContractPayments.Any(z => z.Id == entityId)));
        }

        private async Task<bool> canCustomerViewMonthlyPaymentAsync(int userId, int entityId)
        {
            return await this._userRepository.RepositoryTable
                .AnyAsync(x => x.Id == userId 
                    && x.ContractCustomers.Any(y => y.Contract.ContractMonthlyPayments.Any(z => z.Id == entityId)));
        }
    }
}
