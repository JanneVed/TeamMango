using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models.Repository
{
    public interface IPurchaseRepository
    {
        PurchaseModel CreateNewPurchase(PurchaseModel purcheseChanges);
        IEnumerable<PurchaseModel> GetAllPurchases();
        PurchaseModel UpdatePurchase(PurchaseModel purchase);
    }
}
