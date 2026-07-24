public class CustomerService
{
    private readonly ICustomerRepository repository;

    public CustomerService(ICustomerRepository repository)
    {
        this.repository = repository;
    }

    public string GetCustomer(int customerId)
    {
        return repository.GetCustomerName(customerId);
    }
}