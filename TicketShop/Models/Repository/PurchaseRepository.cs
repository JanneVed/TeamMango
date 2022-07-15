using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Data;

namespace TicketShop.Models.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly TicketShopDbContext _Context;

        public PurchaseRepository(TicketShopDbContext context)
        {
            _Context = context;
        }

        public PurchaseModel CreateNewPurchase(PurchaseModel purchase)
        {
            _Context.Purchases.Add(purchase);
            _Context.SaveChanges();
            return purchase;
        }

        public IEnumerable<PurchaseModel> GetAllPurchases()
        {
            var purchase = _Context.Purchases;
            return purchase;
        }

        public PurchaseModel UpdatePurchase(PurchaseModel purchaseChanges)
        {
            var purchase = _Context.Purchases.Attach(purchaseChanges);
            purchase.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
            return purchaseChanges;
        }
    }
}
