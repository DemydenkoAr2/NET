namespace DoctorAppointmentDemo.Service.Interfaces;

public interface IService<TService> where TService : class
{
    TService Create(TService doctor);

    IEnumerable<TService> GetAll();

    TService? Get(int id);

    bool Delete(int id);

    TService Update(int id, TService doctor);
}