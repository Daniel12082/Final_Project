using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IUnitOfWork{
        IBoss Bosses { get; }
        ICity Cities {get;}
        IClient Clients {get;}
        IContact Contacts {get;}
        ICountry Countries {get;}
        IEmployee Employee {get;}
        ILocationClient LocationClients {get;}
        ILocationOffice LocationOffices {get;}
        IOffice Offices {get;}
        IOrder Orders {get;}
        IOrderDetail OrderDetails {get;}
        IPayment Payment {get;}
        IProduct Products {get;}
        IProductLine ProductLines {get;}
        IProveedor Proveedores {get;}
        IState States {get;}
        IUser User {get;}
        Task<int> SaveAsync();
    }

