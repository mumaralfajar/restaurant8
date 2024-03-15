using restaurant.Models.DTO.Request;
using restaurant.Models.DTO.Response;
using restaurant.Models.DTO;
using restaurant.Models;

namespace restaurant.Services.Interfaces
{
    public interface ITransactionService
    {
        ICollection<Transaction> GetTransactions();
        ResponseAPI<TransactionResponse> GetDetailTransaction(int transactionId);
        ResponseAPI<TransactionResponse> AddTransaction(TransactionRequest request);
        ResponseAPI<TransactionResponse> EditTransaction(int transactionId, TransactionRequest request);
        ResponseAPI<TransactionResponse> DeleteTransaction(int transactionId);
    }
}
