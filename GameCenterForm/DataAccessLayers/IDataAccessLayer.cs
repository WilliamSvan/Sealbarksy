using System.Data;

namespace GameCenterForm.DataAccessLayers
{
    interface IDataAccessLayer
    {
        DataSet GetAll();
        void Insert(object o);
        void Delete(object o);
        void Update(object o);
        DataSet Find(string searchTerm);

    }
}
