
using Application.Repository;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly JardineriaContext _context;
    public UnitOfWork(JardineriaContext context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    private IBoss _bosses;
    private ICity _cities;
    private IContact _contacts;
    private ICountry _countries;
    private IEmployee _employee;
    private ILocationClient _locationClients;
    private ILocationOffice _locationOffices;
    private IOffice _offices;
    private IOrder _orders;
    private IOrderDetail _orderDetails;
    private IPayment _payment;
    private IProduct _products;
    private IProductLine _productLines;
    private IProveedor _proveedores;
    private IState _states;
    private IUser _user;
    public IBoss Bosses {
        get
        {
            if (_bosses == null)
            {
                _bosses = new BossRepository(_context);
            }
            return _bosses;
        }
    }

    public IContact Contacts {
        get
        {
            if (_contacts == null)
            {
                _contacts = new ContactRepository(_context);
            }
            return _contacts;
        }
    }

    public ICountry Countries {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepository(_context);
            }
            return _countries;
        }
    }

    public IEmployee Employee {
        get
        {
            if (_employee == null)
            {
                _employee = new EmployeeRepository(_context);
            }
            return _employee;
        }
    }

    public ILocationClient LocationClients {
        get
        {
            if (_locationClients == null)
            {
                _locationClients = new LocationClientRepository(_context);
            }
            return _locationClients;
        }
    }

    public ILocationOffice LocationOffices {
        get
        {
            if (_locationOffices == null)
            {
                _locationOffices = new LocationOfficeRepository(_context);
            }
            return _locationOffices;
        }
    }

    public IOffice Offices {
        get
        {
            if (_offices == null)
            {
                _offices = new OfficeRepository(_context);
            }
            return _offices;
        }
    }

    public IOrder Orders 
    {
        get
        {
            if (_orders == null)
            {
                _orders = new OrderRepository(_context);
            }
            return _orders;
        }
    }

    public IOrderDetail OrderDetails
    {
        get
        {
            if (_orderDetails == null)
            {
                _orderDetails = new OrderDetailRepository(_context);
            }
            return _orderDetails;
        }
    }
    public IPayment Payment 
    {
        get
        {
            if (_payment == null)
            {
                _payment = new PaymentRepository(_context);
            }
            return _payment;
        }
    }

    public IProduct Products 
    {
        get
        {
            if (_products == null)
            {
                _products = new ProductRepository(_context);
            }
            return _products;
        }
    }

    public IProductLine ProductLines 
    {
        get
        {
            if (_productLines == null)
            {
                _productLines = new ProductLineRepository(_context);
            }
            return _productLines;
        }
    
    }

    public IProveedor Proveedores 
    {
        get
        {
            if (_proveedores == null)
            {
                _proveedores = new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    
    }

    public IState States {
        get
        {
            if (_states == null)
            {
                _states = new StateRepository(_context);
            }
            return _states;
        }
    }

    public ICity Cities 
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepository(_context);
            }
            return _cities;
        }
    }

    public IUser User {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(_context);
            }
            return _user;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}